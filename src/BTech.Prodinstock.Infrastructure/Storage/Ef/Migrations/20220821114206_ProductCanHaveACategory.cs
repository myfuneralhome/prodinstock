using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTech.Prodinstock.Infrastructure.Migrations
{
    public partial class ProductCanHaveACategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                schema: "product",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "product",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "product",
                table: "Products",
                column: "CategoryId",
                principalSchema: "product",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "product",
                table: "Products");
        }
    }
}
