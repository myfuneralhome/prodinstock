using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTech.Prodinstock.Infrastructure.Migrations
{
    public partial class InvoiceCreationDateMustBeDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "product",
                table: "Invoice",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                schema: "product",
                table: "Invoice",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
