using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class RemovePublishFromPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 4, 5, 10, 30, 46, 96, DateTimeKind.Local), new DateTime(2020, 4, 5, 10, 30, 46, 96, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 4, 5, 10, 30, 46, 93, DateTimeKind.Local), new DateTime(2020, 4, 5, 10, 30, 46, 94, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Posts",
                nullable: false,
                defaultValue: false);

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
    }
}
