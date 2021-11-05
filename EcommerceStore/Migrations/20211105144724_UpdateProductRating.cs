using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class UpdateProductRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "PRODUCT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PRODUCT");
        }
    }
}
