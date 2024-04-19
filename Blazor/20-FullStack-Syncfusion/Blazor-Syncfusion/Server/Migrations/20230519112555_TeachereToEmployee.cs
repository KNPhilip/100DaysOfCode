using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorSyncfusion.Server.Migrations
{
    /// <inheritdoc />
    public partial class TeachereToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Employees_TeacherId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Notes",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_TeacherId",
                table: "Notes",
                newName: "IX_Notes_EmployeeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Employees_EmployeeId",
                table: "Notes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Employees_EmployeeId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Notes",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_EmployeeId",
                table: "Notes",
                newName: "IX_Notes_TeacherId");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateHired",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 15, 18, 45, 18, 926, DateTimeKind.Local).AddTicks(4054));

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Employees_TeacherId",
                table: "Notes",
                column: "TeacherId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
