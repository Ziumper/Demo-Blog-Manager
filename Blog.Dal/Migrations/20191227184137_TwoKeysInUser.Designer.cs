﻿// <auto-generated />
using System;
using Blog.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Dal.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20191227184137_TwoKeysInUser")]
    partial class TwoKeysInUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Dal.Models.BlogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new { Id = 1, CreationDate = new DateTime(2019, 12, 27, 19, 41, 36, 746, DateTimeKind.Local), ModificationDate = new DateTime(2019, 12, 27, 19, 41, 36, 746, DateTimeKind.Local), Title = "Programming Blog", UserId = 1 }
                    );
                });

            modelBuilder.Entity("Blog.Dal.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Blog.Dal.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Extension");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Blog.Dal.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("IsPublished");

                    b.Property<int?>("MainImageId");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("MainImageId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Blog.Dal.Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Username");

                    b.Property<string>("ActivationCode");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Password");

                    b.HasKey("Id", "Username");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 0, Username = "Tomasz", ActivationCode = "CDN8", CreationDate = new DateTime(2019, 12, 27, 19, 41, 36, 743, DateTimeKind.Local), Email = "tomasz.komoszeski@gmail.com", FirstName = "Tomasz", IsActive = true, LastName = "Komoszeski", ModificationDate = new DateTime(2019, 12, 27, 19, 41, 36, 745, DateTimeKind.Local), Password = "d9d420ec1652e5a5a826432a363c45bc2622aaf6725188c8a4c826bf68a5675f" }
                    );
                });

            modelBuilder.Entity("Blog.Dal.Models.Comment", b =>
                {
                    b.HasOne("Blog.Dal.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Blog.Dal.Models.Post", b =>
                {
                    b.HasOne("Blog.Dal.Models.BlogEntity", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.Dal.Models.Image", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId");
                });

            modelBuilder.Entity("Blog.Dal.Models.User", b =>
                {
                    b.HasOne("Blog.Dal.Models.BlogEntity", "Blog")
                        .WithOne("User")
                        .HasForeignKey("Blog.Dal.Models.User", "Id")
                        .HasPrincipalKey("Blog.Dal.Models.BlogEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
