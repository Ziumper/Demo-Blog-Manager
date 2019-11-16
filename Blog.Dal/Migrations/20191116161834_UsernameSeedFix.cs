using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class UsernameSeedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2019, 11, 16, 17, 18, 33, 785, DateTimeKind.Local), new DateTime(2019, 11, 16, 17, 18, 33, 785, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate", "Username" },
                values: new object[] { new DateTime(2019, 11, 16, 17, 18, 33, 783, DateTimeKind.Local), new DateTime(2019, 11, 16, 17, 18, 33, 784, DateTimeKind.Local), "Tomasz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2019, 11, 16, 16, 57, 31, 152, DateTimeKind.Local), new DateTime(2019, 11, 16, 16, 57, 31, 152, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate", "Username" },
                values: new object[] { new DateTime(2019, 11, 16, 16, 57, 31, 150, DateTimeKind.Local), new DateTime(2019, 11, 16, 16, 57, 31, 151, DateTimeKind.Local), null });
        }
    }
}
