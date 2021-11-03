using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoTestMe.Admin.Web.Migrations
{
    public partial class addnewproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "TestQuestions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "CoursePages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "CoursePages");
        }
    }
}
