using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAndUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a418f09-e588-4f30-9624-5c7989fa3956", "b51fd6cc-f468-4daa-ac2e-b1e1cdc78baf", "User", "user" },
                    { "b67c3305-b802-4535-a8b7-e443a05ad783", "e078f097-2ce1-40dc-9b08-eeeaccf7c4e2", "Admin", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 8, 1, 51, 10, 999, DateTimeKind.Local).AddTicks(1684));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a418f09-e588-4f30-9624-5c7989fa3956");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b67c3305-b802-4535-a8b7-e443a05ad783");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 7, 23, 7, 47, 484, DateTimeKind.Local).AddTicks(4932));
        }
    }
}
