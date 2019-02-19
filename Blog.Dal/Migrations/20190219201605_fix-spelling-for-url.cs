using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Dal.Migrations
{
    public partial class fixspellingforurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ulr",
                table: "Images",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "Ulr");
        }
    }
}
