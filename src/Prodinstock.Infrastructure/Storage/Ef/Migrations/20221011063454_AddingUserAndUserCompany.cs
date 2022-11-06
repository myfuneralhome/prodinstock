using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prodinstock.Infrastructure.Migrations
{
    public partial class AddingUserAndUserCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCompanyId",
                schema: "product",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCompanyId",
                schema: "product",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCompanyId",
                schema: "product",
                table: "Invoice",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCompanyId",
                schema: "product",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "product",
                table: "AccountingAccount",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "UserCompanyId",
                schema: "product",
                table: "AccountingAccount",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserCompany",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    LegalName = table.Column<string>(type: "text", nullable: false),
                    CompanyRegistrationNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserCompanyId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserCompany_UserCompanyId",
                        column: x => x.UserCompanyId,
                        principalSchema: "product",
                        principalTable: "UserCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UserCompanyId",
                schema: "product",
                table: "Supplier",
                column: "UserCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserCompanyId",
                schema: "product",
                table: "Invoice",
                column: "UserCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_UserCompanyId",
                schema: "product",
                table: "Category",
                column: "UserCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingAccount_UserCompanyId",
                schema: "product",
                table: "AccountingAccount",
                column: "UserCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserCompanyId",
                schema: "product",
                table: "User",
                column: "UserCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingAccount_UserCompany_UserCompanyId",
                schema: "product",
                table: "AccountingAccount",
                column: "UserCompanyId",
                principalSchema: "product",
                principalTable: "UserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_UserCompany_UserCompanyId",
                schema: "product",
                table: "Category",
                column: "UserCompanyId",
                principalSchema: "product",
                principalTable: "UserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_UserCompany_UserCompanyId",
                schema: "product",
                table: "Invoice",
                column: "UserCompanyId",
                principalSchema: "product",
                principalTable: "UserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_UserCompany_UserCompanyId",
                schema: "product",
                table: "Supplier",
                column: "UserCompanyId",
                principalSchema: "product",
                principalTable: "UserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingAccount_UserCompany_UserCompanyId",
                schema: "product",
                table: "AccountingAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_UserCompany_UserCompanyId",
                schema: "product",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_UserCompany_UserCompanyId",
                schema: "product",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_UserCompany_UserCompanyId",
                schema: "product",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "User",
                schema: "product");

            migrationBuilder.DropTable(
                name: "UserCompany",
                schema: "product");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_UserCompanyId",
                schema: "product",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_UserCompanyId",
                schema: "product",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Category_UserCompanyId",
                schema: "product",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_AccountingAccount_UserCompanyId",
                schema: "product",
                table: "AccountingAccount");

            migrationBuilder.DropColumn(
                name: "UserCompanyId",
                schema: "product",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UserCompanyId",
                schema: "product",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserCompanyId",
                schema: "product",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "UserCompanyId",
                schema: "product",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UserCompanyId",
                schema: "product",
                table: "AccountingAccount");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "product",
                table: "AccountingAccount",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
