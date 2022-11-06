using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prodinstock.Infrastructure.Migrations
{
    public partial class ProductCanHaveASupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierId",
                schema: "product",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                schema: "product",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supplier_SupplierId",
                schema: "product",
                table: "Products",
                column: "SupplierId",
                principalSchema: "product",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supplier_SupplierId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "product",
                table: "Products");
        }
    }
}
