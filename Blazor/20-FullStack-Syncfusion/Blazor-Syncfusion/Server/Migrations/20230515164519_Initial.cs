using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusion.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFired = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Employees_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DateFired", "DateHired", "DateLastUpdated", "FirstName", "IsEmployee", "LastName", "Mail", "NickName", "Phone", "School", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3871), null, "Kenneth", true, "Hougaard Soerensen", "keso@aspit.dk", "KESO", null, "AspIT Trekanten", "Lærer" },
                    { 2, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3919), null, "Mads", true, "Mikkel Rasmussen", "mara@aspit.dk", "MARA", null, "AspIT Trekanten", "Lærer" },
                    { 3, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3923), null, "Dea", true, "Gram", "degr@aspin.dk", "DEGR", null, "AspIN", "Lærer" },
                    { 4, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3925), null, "Jan", true, "Lindgaard Pedersen", "jape@aspin.dk", "JAPE", null, "AspIN", "Lærer" },
                    { 5, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3928), null, "Jesper", true, "Lade Mathiesen", "jema@aspit.dk", "JEMA", "+45 72 16 28 56", "AspIT Trekanten", "Specialpædagogisk vejleder" },
                    { 6, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3931), null, "Henrik", true, "Stephansen", "hens@aspit.dk", "HENS", "+45 72 16 26 85", "AspIT Trekanten", "Praktik- og jobvejleder" },
                    { 7, new DateTime(1994, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3933), null, "Ole", true, "Bay Jensen", "oje@aspit.dk", "OJE", "+45 72 16 27 99", "AspIT Trekanten", "Uddannelseschef" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "DateCreated", "TeacherId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(4050), 5, "ADHD child and very annoying." },
                    { 2, new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(4054), 1, "funny." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TeacherId",
                table: "Notes",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
