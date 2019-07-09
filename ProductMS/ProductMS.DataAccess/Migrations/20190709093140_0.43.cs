using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMS.DataAccess.Migrations
{
    public partial class _043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Test2",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test2",
                table: "Products",
                nullable: true);
        }
    }
}
