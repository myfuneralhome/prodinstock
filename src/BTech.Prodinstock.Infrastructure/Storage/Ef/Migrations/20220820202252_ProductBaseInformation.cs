using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTech.Prodinstock.Infrastructure.Migrations
{
    public partial class ProductBaseInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumberInStock = table.Column<short>(type: "smallint", nullable: false),
                    SalePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    VATRate = table.Column<decimal>(type: "numeric", nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "product");
        }
    }
}
