using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyApp.Migrations
{
    public partial class CurrencyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(nullable: false),
                    fromCurrency = table.Column<string>(nullable: true),
                    toCurrency = table.Column<string>(maxLength: 3, nullable: true),
                    CreateDatetime = table.Column<DateTime>(nullable: false),
                    UpdateDatetime = table.Column<DateTime>(nullable: false),
                    Removed = table.Column<int>(nullable: false)
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
