using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "PRODUCT");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "PRODUCT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "PRODUCT");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PRODUCT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Storage",
                table: "PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
