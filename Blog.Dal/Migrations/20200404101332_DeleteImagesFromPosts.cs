using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class DeleteImagesFromPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 4, 4, 12, 13, 31, 961, DateTimeKind.Local), new DateTime(2020, 4, 4, 12, 13, 31, 961, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 4, 4, 12, 13, 31, 958, DateTimeKind.Local), new DateTime(2020, 4, 4, 12, 13, 31, 960, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    Extension = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 12, 13, 32, 27, 801, DateTimeKind.Local), new DateTime(2020, 1, 12, 13, 32, 27, 801, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 12, 13, 32, 27, 798, DateTimeKind.Local), new DateTime(2020, 1, 12, 13, 32, 27, 800, DateTimeKind.Local) });

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
    }
}
