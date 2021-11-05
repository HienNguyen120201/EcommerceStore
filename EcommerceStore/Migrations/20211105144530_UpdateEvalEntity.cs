using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceStore.Migrations
{
    public partial class UpdateEvalEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVALUATION",
                columns: table => new
                {
                    EvalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    EvalTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVALUATION", x => x.EvalID);
                    table.ForeignKey(
                        name: "FK_EVALUATION_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EVALUATION_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCT",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EVALUATION_CustomerId",
                table: "EVALUATION",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EVALUATION_ProductId",
                table: "EVALUATION",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVALUATION");
        }
    }
}
