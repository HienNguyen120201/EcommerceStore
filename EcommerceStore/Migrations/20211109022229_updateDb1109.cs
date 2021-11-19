using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class updateDb1109 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressReceive",
                table: "BILL");

            migrationBuilder.AddColumn<string>(
                name: "Huyen",
                table: "BILL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "BILL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thon",
                table: "BILL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tinh",
                table: "BILL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BILL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Xa",
                table: "BILL",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BILLPRODUCT_ProductId",
                table: "BILLPRODUCT",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BILLPRODUCT_PRODUCT_ProductId",
                table: "BILLPRODUCT",
                column: "ProductId",
                principalTable: "PRODUCT",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BILLPRODUCT_PRODUCT_ProductId",
                table: "BILLPRODUCT");

            migrationBuilder.DropIndex(
                name: "IX_BILLPRODUCT_ProductId",
                table: "BILLPRODUCT");

            migrationBuilder.DropColumn(
                name: "Huyen",
                table: "BILL");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BILL");

            migrationBuilder.DropColumn(
                name: "Thon",
                table: "BILL");

            migrationBuilder.DropColumn(
                name: "Tinh",
                table: "BILL");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BILL");

            migrationBuilder.DropColumn(
                name: "Xa",
                table: "BILL");

            migrationBuilder.AddColumn<string>(
                name: "AddressReceive",
                table: "BILL",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
