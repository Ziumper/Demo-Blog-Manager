using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace Blog.Dal
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        public BloggingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BloggingContext>();
            var configuration = this.GetConfiguration();
            //TODO Add connection configuration from single file.
            var connection = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connection);
            return new BloggingContext(builder.Options);
        }

        private IConfiguration GetConfiguration() {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            string basePath = Path.Combine(Directory.GetCurrentDirectory(),"../Blog.Web");
            builder.SetBasePath(basePath).AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            return configuration;
        }
    }
}
