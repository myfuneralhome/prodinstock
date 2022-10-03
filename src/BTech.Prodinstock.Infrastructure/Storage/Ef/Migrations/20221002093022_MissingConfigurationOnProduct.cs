using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTech.Prodinstock.Infrastructure.Migrations
{
    public partial class MissingConfigurationOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                schema: "product",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                schema: "product",
                table: "OrderProduct",
                column: "ProductId",
                principalSchema: "product",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                schema: "product",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductId",
                schema: "product",
                table: "OrderProduct");
        }
    }
}
