using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class UpdateMainDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainDesc",
                table: "PRODUCT");

            migrationBuilder.AddColumn<string>(
                name: "MainDesc",
                table: "DESCRIPTION",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainDesc",
                table: "DESCRIPTION");

            migrationBuilder.AddColumn<string>(
                name: "MainDesc",
                table: "PRODUCT",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
