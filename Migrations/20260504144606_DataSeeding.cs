using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank_management__System.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@bank.com", "Ahmed Hassan", new DateOnly(2023, 5, 15), "01012345678" },
                    { 2, "sara.mohamed@bank.com", "Sara Mohamed", new DateOnly(2024, 1, 10), "01198765432" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "Phone" },
                values: new object[,]
                {
                    { 101, "ElMamora", 1, "Alex", "0223456789" },
                    { 102, "ElThrier", 2, "Cairo", "0345678901" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "BranchCode", "CurrentBalance", "OpeingDate" },
                values: new object[,]
                {
                    { 1000001, "Saving", 101, 50000.75m, new DateTime(2025, 11, 4, 17, 46, 4, 676, DateTimeKind.Local).AddTicks(1490) },
                    { 1000002, "Current", 101, 125000.00m, new DateTime(2026, 2, 4, 17, 46, 4, 676, DateTimeKind.Local).AddTicks(1618) },
                    { 1000003, "Saving", 102, 7500.50m, new DateTime(2026, 4, 4, 17, 46, 4, 676, DateTimeKind.Local).AddTicks(1632) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1000001);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1000002);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1000003);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
