using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class MyLastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OldPrice",
                table: "PRODUCT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "PRODUCT");
        }
    }
}
