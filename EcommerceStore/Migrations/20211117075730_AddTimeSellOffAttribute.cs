using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class AddTimeSellOffAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeSellOff",
                table: "PRODUCT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSellOff",
                table: "PRODUCT");
        }
    }
}
