using System;
using Blog.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Dal
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
        : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupRelations(modelBuilder);
            CreateSeedData(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<Image> Images {get; set;}
        public DbSet<User> Users {get; set;}

        private void SetupRelations(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasOne( u => u.Blog).WithOne(b => b.User)
            .HasForeignKey<BlogEntity>(b => b.UserId);
        }

        private void CreateSeedData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User(){
                    Id = 1,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    FirstName = "Tomasz",
                    LastName = "Komoszeski",
                    //MistrzTomasz10!
                    Password = "d9d420ec1652e5a5a826432a363c45bc2622aaf6725188c8a4c826bf68a5675f",
                    IsActive = true,
                    Email = "tomasz.komoszeski@gmail.com",
                    ActivationCode = "CDN8",
                    Username = "Tomasz"
                });

            modelBuilder.Entity<BlogEntity>().HasData(
                new BlogEntity() {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    Title = "Programming Blog",
                    UserId = 1
                }
            );
        }

        

    }
}
