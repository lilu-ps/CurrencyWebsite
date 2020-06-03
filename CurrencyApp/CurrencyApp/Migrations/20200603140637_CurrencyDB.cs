using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyApp.Migrations
{
    public partial class CurrencyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatroOperations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromCurrency = table.Column<string>(nullable: false),
                    toCurrency = table.Column<string>(nullable: false),
                    CreateDatetime = table.Column<DateTime>(nullable: false),
                    sell = table.Column<decimal>(nullable: false),
                    buy = table.Column<decimal>(nullable: false),
                    comment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatroOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyRate = table.Column<decimal>(nullable: false),
                    SellRate = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    CurrencyName = table.Column<string>(nullable: false),
                    CurrencyNameLatin = table.Column<string>(nullable: false),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatroOperations");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "RegisteredList");
        }
    }
}
