using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class AddRoleStringToUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);

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
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 3, 19, 23, 2, 65, DateTimeKind.Local), new DateTime(2020, 1, 3, 19, 23, 2, 67, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 3, 17, 16, 12, 394, DateTimeKind.Local), new DateTime(2020, 1, 3, 17, 16, 12, 394, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 3, 17, 16, 12, 390, DateTimeKind.Local), new DateTime(2020, 1, 3, 17, 16, 12, 393, DateTimeKind.Local) });
        }
    }
}
