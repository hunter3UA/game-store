using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 0.0, 70m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 0.0, 50m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 0.0, 50m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 5, 10, 15, 0, 19, 291, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 5, 10, 15, 0, 19, 293, DateTimeKind.Local).AddTicks(3830));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 10.0, 100m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 10.0, 70m });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 10.0, 70m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 5, 10, 14, 55, 0, 77, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 5, 10, 14, 55, 0, 80, DateTimeKind.Local).AddTicks(6237));
        }
    }
}
