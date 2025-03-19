using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a19b888-2873-4716-b79e-79e14b1c16b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa1762ea-4420-4bb8-bc02-74c1f6223a14");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiscountId",
                schema: "inventory",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b2bcbd2-bd4e-42e8-8faf-7f229bb6a230", null, "admin", "ADMIN" },
                    { "b0b42512-361f-4c02-8bc1-cb8d15d214ab", null, "customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b2bcbd2-bd4e-42e8-8faf-7f229bb6a230");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0b42512-361f-4c02-8bc1-cb8d15d214ab");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiscountId",
                schema: "inventory",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a19b888-2873-4716-b79e-79e14b1c16b1", null, "Customer", "Customer" },
                    { "aa1762ea-4420-4bb8-bc02-74c1f6223a14", null, "Admin", "Admin" }
                });
        }
    }
}
