using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyProject.Migrations
{
    public partial class CurrDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyValue = table.Column<decimal>(maxLength: 3, nullable: false),
                    fromCurrency = table.Column<string>(nullable: true),
                    toCurrency = table.Column<string>(maxLength: 3, nullable: true),
                    Datetime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
