using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class ImagesForPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainImageId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MainImageId",
                table: "Posts",
                column: "MainImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Images_MainImageId",
                table: "Posts",
                column: "MainImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Images_MainImageId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Posts_MainImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Posts");
        }
    }
}
