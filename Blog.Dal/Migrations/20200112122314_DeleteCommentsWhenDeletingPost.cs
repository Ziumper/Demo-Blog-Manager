using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class DeleteCommentsWhenDeletingPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 12, 13, 23, 14, 562, DateTimeKind.Local), new DateTime(2020, 1, 12, 13, 23, 14, 562, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2020, 1, 12, 13, 23, 14, 559, DateTimeKind.Local), new DateTime(2020, 1, 12, 13, 23, 14, 561, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
