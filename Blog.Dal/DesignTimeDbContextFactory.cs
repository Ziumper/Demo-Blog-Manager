using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.Dal
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        public BloggingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BloggingContext>();
            //TODO Add connection configuration from single file.
            var connection = @"Server=.\SQLExpress;Database=BlogDatabase;Trusted_Connection=True;ConnectRetryCount=0";

            builder.UseSqlServer(connection);

            return new BloggingContext(builder.Options);
        }
    }
}
