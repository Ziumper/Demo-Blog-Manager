﻿using Blog.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dal
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
        : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBulider)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<Image> Images {get; set;}
        public DbSet<User> Users {get; set;}
    }
}
