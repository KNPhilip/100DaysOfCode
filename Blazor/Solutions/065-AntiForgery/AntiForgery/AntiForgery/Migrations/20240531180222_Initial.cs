using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AntiForgery.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 1, 8), "Freezing", -13 },
                    { 2, new DateOnly(2022, 1, 9), "Chilly", -2 },
                    { 3, new DateOnly(2022, 1, 10), "Freezing", 1 },
                    { 4, new DateOnly(2022, 1, 17), "Balmy", -16 },
                    { 5, new DateOnly(2022, 1, 19), "Bracing", 14 },
                    { 6, new DateOnly(2022, 1, 22), "Chilly", -2 },
                    { 7, new DateOnly(2022, 1, 24), "Freezing", -13 },
                    { 8, new DateOnly(2022, 1, 25), "Bracing", 14 },
                    { 9, new DateOnly(2022, 2, 6), "Balmy", -16 },
                    { 10, new DateOnly(2022, 2, 7), "Freezing", -13 },
                    { 11, new DateOnly(2022, 2, 9), "Freezing", 1 },
                    { 12, new DateOnly(2022, 2, 12), "Bracing", 14 },
                    { 13, new DateOnly(2022, 2, 16), "Chilly", -2 },
                    { 14, new DateOnly(2022, 2, 22), "Balmy", -16 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
