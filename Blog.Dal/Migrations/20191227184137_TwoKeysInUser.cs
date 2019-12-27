using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class TwoKeysInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                columns: new[] { "Id", "Username" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2019, 12, 27, 19, 41, 36, 746, DateTimeKind.Local), new DateTime(2019, 12, 27, 19, 41, 36, 746, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "ActivationCode", "CreationDate", "Email", "FirstName", "IsActive", "LastName", "ModificationDate", "Password" },
                values: new object[] { 0, "Tomasz", "CDN8", new DateTime(2019, 12, 27, 19, 41, 36, 743, DateTimeKind.Local), "tomasz.komoszeski@gmail.com", "Tomasz", true, "Komoszeski", new DateTime(2019, 12, 27, 19, 41, 36, 745, DateTimeKind.Local), "d9d420ec1652e5a5a826432a363c45bc2622aaf6725188c8a4c826bf68a5675f" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Blogs_Id",
                table: "Users",
                column: "Id",
                principalTable: "Blogs",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Blogs_Id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Blogs_UserId",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumns: new[] { "Id", "Username" },
                keyValues: new object[] { 0, "Tomasz" });

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "CreationDate", "Email", "FirstName", "IsActive", "LastName", "ModificationDate", "Password", "Username" },
                values: new object[] { 1, "CDN8", new DateTime(2019, 11, 16, 17, 18, 33, 783, DateTimeKind.Local), "tomasz.komoszeski@gmail.com", "Tomasz", true, "Komoszeski", new DateTime(2019, 11, 16, 17, 18, 33, 784, DateTimeKind.Local), "d9d420ec1652e5a5a826432a363c45bc2622aaf6725188c8a4c826bf68a5675f", "Tomasz" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2019, 11, 16, 17, 18, 33, 785, DateTimeKind.Local), new DateTime(2019, 11, 16, 17, 18, 33, 785, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
