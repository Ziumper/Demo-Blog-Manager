using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class CascadeForBlogDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogEntityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BlogEntityId",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 11, 12, 10, 1, 308, DateTimeKind.Local), new DateTime(2020, 1, 11, 12, 10, 1, 308, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 11, 12, 10, 1, 306, DateTimeKind.Local), new DateTime(2020, 1, 11, 12, 10, 1, 308, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "BlogEntityId",
                table: "Posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 3, 19, 25, 37, 574, DateTimeKind.Local), new DateTime(2020, 1, 3, 19, 25, 37, 574, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 3, 19, 25, 37, 570, DateTimeKind.Local), new DateTime(2020, 1, 3, 19, 25, 37, 572, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogEntityId",
                table: "Posts",
                column: "BlogEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogEntityId",
                table: "Posts",
                column: "BlogEntityId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
