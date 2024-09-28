using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BitsOrchestraTestApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DateOfBirth", "Married", "Name", "Phone", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Flory McLuckie", "678-606-5234", 5739m },
                    { 2, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Angelo Iacobetto", "718-384-4919", 504m },
                    { 3, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Eada Frome", "747-226-5268", 23585m },
                    { 4, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ibbie Glewe", "505-161-4189", 36789m },
                    { 5, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ashly Waldie", "294-825-5871", 944m },
                    { 6, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Holden Ridgeway", "219-790-4260", 1m },
                    { 7, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Arnuad Dimitriou", "787-414-1823", 10m },
                    { 8, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lorianne Sanney", "536-923-6367", 4327m },
                    { 9, new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Filmer Basindale", "937-235-4935", 17243m },
                    { 10, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Rodolphe Cassie", "962-414-2092", 7m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
