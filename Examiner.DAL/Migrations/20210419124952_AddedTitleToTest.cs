using Microsoft.EntityFrameworkCore.Migrations;

namespace Examiner.DAL.Migrations
{
    public partial class AddedTitleToTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tests",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tests");
        }
    }
}
