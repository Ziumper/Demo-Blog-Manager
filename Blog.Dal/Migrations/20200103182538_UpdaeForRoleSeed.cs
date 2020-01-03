using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class UpdaeForRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreationDate", "ModificationDate", "Role" },
                values: new object[] { new DateTime(2020, 1, 3, 19, 25, 37, 570, DateTimeKind.Local), new DateTime(2020, 1, 3, 19, 25, 37, 572, DateTimeKind.Local), "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 3, 19, 23, 2, 69, DateTimeKind.Local), new DateTime(2020, 1, 3, 19, 23, 2, 69, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate", "Role" },
                values: new object[] { new DateTime(2020, 1, 3, 19, 23, 2, 65, DateTimeKind.Local), new DateTime(2020, 1, 3, 19, 23, 2, 67, DateTimeKind.Local), null });
        }
    }
}
