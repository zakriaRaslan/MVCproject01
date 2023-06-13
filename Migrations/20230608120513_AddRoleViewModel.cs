using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a418f09-e588-4f30-9624-5c7989fa3956");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b67c3305-b802-4535-a8b7-e443a05ad783");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77d26972-7773-4ed2-8700-054637db1df0", "f7aba753-223f-44a8-b14a-5069804f406e", "User", "user" },
                    { "90ef059e-2b54-4eb4-9511-5fe599554c72", "2c0001ab-47af-4a07-8a0d-5d1c150218d6", "Admin", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 8, 15, 5, 13, 773, DateTimeKind.Local).AddTicks(480));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d26972-7773-4ed2-8700-054637db1df0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90ef059e-2b54-4eb4-9511-5fe599554c72");

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
    }
}
