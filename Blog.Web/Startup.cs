using Blog.Dal;
using AutoMapper;
using Blog.Bll.Services.Posts;
using Blog.Bll.Services.Comments;
using Blog.Dal.Repositories.Posts;
using Blog.Dal.Repositories.Comments;
using Blog.Bll.Middlewares;
using Blog.Dal.Repositories.Tags;
using Blog.Dal.Repositories.Blogs;
using Blog.Bll.Services.Blogs;
using Blog.Bll.Services.Tags;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Blog.Bll.Services.Images.ImageWriter;
using Blog.Bll.Services.Images;
using Blog.Dal.Repositories.Images;
using Blog.Bll.Services;
using Microsoft.AspNetCore.Http;
using Blog.Bll.Services.Users;
using Blog.Dal.Repositories;
using Blog.Dal.Repositories.Users;
using Blog.Bll.Services.Utility;
using Blog.Bll.Services.Emails;

namespace Blog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup).Assembly);
        

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            var connection = @"Server=.\SQLExpress;Database=BlogDatabase;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));

            ConfiugreDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }
            else
            {
               // app.UseExceptionHandler("/Error");
               // app.UseHsts();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseHttpContext();
            app.UseMvc(routes =>
            {
                  routes.MapRoute(
                    "API",
                    "api/{controller=*}/{action=*}/{id?}");

                routes.MapRoute(
                    "Default", // Route name
                    "{*catchall}", // URL with parameters
                    new { controller = "Home", action = "Index" });

                /*routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}"); * */
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        
        private void ConfiugreDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IImageWriter,ImplImageWriter>();
            services.AddTransient<IImageFormatValidator,ImageFormatValidator>();
            services.AddTransient<IImageService,ImageService>();
            services.AddTransient<IImageRepository,ImageRepository>();
            services.AddTransient<IParserService, ParserService>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IEmailService, EmailService> ();
        }
    }
}
