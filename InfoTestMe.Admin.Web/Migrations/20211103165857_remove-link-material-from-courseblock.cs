using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoTestMe.Admin.Web.Migrations
{
    public partial class removelinkmaterialfromcourseblock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkMaterial",
                table: "CourseBlocks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkMaterial",
                table: "CourseBlocks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
