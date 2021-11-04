using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoTestMe.Admin.Web.Migrations
{
    public partial class KeyWordsAddToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "Authors");
        }
    }
}
