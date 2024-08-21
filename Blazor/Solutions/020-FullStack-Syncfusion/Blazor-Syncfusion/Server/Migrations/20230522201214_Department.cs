using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusion.Server.Migrations
{
    /// <inheritdoc />
    public partial class Department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 55.710459999999998, 9.5223899999999997, "AspIT Nordjylland" },
                    { 2, 56.150649999999999, 10.20538, "AspIT Østjylland" },
                    { 3, 57.055010000000003, 9.9052000000000007, "AspIT Trekanten" },
                    { 4, null, null, "AspIN" }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(8897), 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(8945), 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(8948), 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(9002), 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(9007), 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(9011), 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateHired", "DepartmentId" },
                values: new object[] { new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(9014), 3 });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 22, 22, 12, 14, 837, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateHired",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 19, 13, 25, 54, 871, DateTimeKind.Local).AddTicks(2671));
        }
    }
}
