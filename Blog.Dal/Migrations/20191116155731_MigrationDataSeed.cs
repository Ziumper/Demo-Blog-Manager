using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class MigrationDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "CreationDate", "Email", "FirstName", "IsActive", "LastName", "ModificationDate", "Password", "Username" },
                values: new object[] { 1, "CDN8", new DateTime(2019, 11, 16, 16, 57, 31, 150, DateTimeKind.Local), "tomasz.komoszeski@gmail.com", "Tomasz", true, "Komoszeski", new DateTime(2019, 11, 16, 16, 57, 31, 151, DateTimeKind.Local), "d9d420ec1652e5a5a826432a363c45bc2622aaf6725188c8a4c826bf68a5675f", null });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreationDate", "ModificationDate", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2019, 11, 16, 16, 57, 31, 152, DateTimeKind.Local), new DateTime(2019, 11, 16, 16, 57, 31, 152, DateTimeKind.Local), "Programming Blog", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
