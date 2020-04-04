using System.Security.Claims;
using System.Text;
using AutoMapper;
using Blog.Bll.Dto.App;
using Blog.Bll.Middlewares;
using Blog.Bll.Services.Authentication;
using Blog.Bll.Services.Authorization;
using Blog.Bll.Services.Blogs;
using Blog.Bll.Services.Comments;
using Blog.Bll.Services.Emails;
using Blog.Bll.Services.Posts;
using Blog.Bll.Services.Users;
using Blog.Bll.Services.Utility;
using Blog.Dal;
using Blog.Dal.Repositories;
using Blog.Dal.Repositories.Blogs;
using Blog.Dal.Repositories.Comments;
using Blog.Dal.Repositories.Posts;
using Blog.Dal.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Web {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
            services.AddAutoMapper (typeof (Startup).Assembly);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/dist";
            });

            AppSettings appSettings = GetAppSettings(services);

            SetupDatabaseConnection(services);
            ConfiugreDependencyInjection (services);
            SetupEmailConfiguration(services);
            AddAuthentication(services,appSettings);
            AddAuthorization(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                // app.UseDeveloperExceptionPage();
            } else {
                // app.UseExceptionHandler("/Error");
                // app.UseHsts();
            }
            app.UseAuthentication();
            app.UseMiddleware (typeof (ErrorHandlingMiddleware));
            //app.UseHttpsRedirection();
            app.UseStaticFiles ();
            app.UseSpaStaticFiles ();
            app.UseHttpContext ();
            app.UseMvc (routes => {
                routes.MapRoute (
                    "API",
                    "api/{controller=*}/{action=*}/{id?}");

                routes.MapRoute (
                    "Default", // Route name
                    "{*catchall}", // URL with parameters
                    new { controller = "Home", action = "Index" });

                /*routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}"); * */
            });

            app.UseSpa (spa => {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment ()) {
                    spa.UseAngularCliServer (npmScript: "start");
                }
            });

           
        }

        private AppSettings GetAppSettings(IServiceCollection services) {
            IConfigurationSection appSettingsSection = Configuration.GetSection ("AppSettings");
            services.Configure<AppSettings> (appSettingsSection);
            AppSettings appSettings = appSettingsSection.Get<AppSettings> ();
            return appSettings;
        }

        private void SetupDatabaseConnection(IServiceCollection services) {
            var connection = Configuration.GetConnectionString ("DefaultConnection");
            services.AddDbContext<BloggingContext> (options => options.UseSqlServer (connection));
        }

        private void ConfiugreDependencyInjection (IServiceCollection services) {

            //Singletons
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
            
            //Transients
            services.AddTransient<IPostService, PostService> ();
            services.AddTransient<ICommentService, CommentService> ();
            services.AddTransient<IBlogService, BlogService> ();
            services.AddTransient<IPostRepository, PostRepository> ();
            services.AddTransient<ICommentRepository, CommentRepository> ();
            services.AddTransient<IBlogRepository, BlogRepository> ();
            services.AddTransient<IParserService, ParserService> ();
            services.AddTransient<IUserService, UserService> ();
            services.AddTransient<IUserRepository, UserRepository> ();
            services.AddTransient<IHashService, HashService> ();
            services.AddTransient<ITokenService,TokenService>();
        }

        private void SetupEmailConfiguration(IServiceCollection services) {
            EmailConfiguration configurationEmailObj = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton<IEmailConfiguration> (configurationEmailObj);
            services.AddTransient<IEmailService, EmailService> ();
        }

        private void AddAuthentication(IServiceCollection services,AppSettings appSettings) {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
            });
        }

        private void AddAuthorization(IServiceCollection services) {
            services.AddAuthorization(options => {
                options.AddPolicy("EditUserPolicy", policy =>
                policy.Requirements.Add(new AuthorUserRequirement()));
                options.AddPolicy("Administrators", policy=> policy.RequireClaim(ClaimTypes.Role,"Administrator"));
            });

            services.AddSingleton<IAuthorizationHandler, UserAuthorizationHandler>();
        }
    }
}