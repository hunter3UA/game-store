using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class FixInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsDeleted", "OrderDate" },
                values: new object[] { 1, 1, false, new DateTime(2022, 5, 14, 15, 38, 1, 547, DateTimeKind.Local).AddTicks(6569) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsDeleted", "OrderDate" },
                values: new object[] { 2, 2, false, new DateTime(2022, 5, 14, 15, 38, 1, 549, DateTimeKind.Local).AddTicks(4437) });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ProductId", "IsDeleted", "OrderId", "Price", "Quantity" },
                values: new object[] { 1, 0.0, 1, false, 1, 70m, (short)1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ProductId", "IsDeleted", "OrderId", "Price", "Quantity" },
                values: new object[] { 2, 0.0, 2, false, 1, 50m, (short)1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ProductId", "IsDeleted", "OrderId", "Price", "Quantity" },
                values: new object[] { 3, 0.0, 2, false, 2, 50m, (short)1 });
        }
    }
}
