using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prodinstock.Infrastructure.Migrations
{
    public partial class ProductCanHaveAccountingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountingAccountId",
                schema: "product",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountingAccount",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingAccount", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountingAccountId",
                schema: "product",
                table: "Products",
                column: "AccountingAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AccountingAccount_AccountingAccountId",
                schema: "product",
                table: "Products",
                column: "AccountingAccountId",
                principalSchema: "product",
                principalTable: "AccountingAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AccountingAccount_AccountingAccountId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropTable(
                name: "AccountingAccount",
                schema: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountingAccountId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountingAccountId",
                schema: "product",
                table: "Products");
        }
    }
}
