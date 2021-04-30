using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PenaltyCalculator.Infrastructure.Migrations
{
    public partial class PenaltyBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    PenaltyAmount = table.Column<double>(type: "float", nullable: false),
                    WeeklyHolidays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holidays_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Turk Lirası" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Dirhem" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CurrencyId", "Name", "PenaltyAmount", "WeeklyHolidays" },
                values: new object[] { 1, 1, "Türkiye", 10.0, 96 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CurrencyId", "Name", "PenaltyAmount", "WeeklyHolidays" },
                values: new object[] { 2, 2, "Birleşik Arap Emirlikleri", 15.0, 48 });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "CountryId", "DateTime", "Name" },
                values: new object[] { 1, 1, new DateTime(1, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "19 Mayıs" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "CountryId", "DateTime", "Name" },
                values: new object[] { 2, 2, new DateTime(1, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arafat Dağı Günü" });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_CountryId",
                table: "Holidays",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
