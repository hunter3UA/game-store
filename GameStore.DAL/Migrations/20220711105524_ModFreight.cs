using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModFreight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Freight",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(2854), new DateTime(2022, 4, 2, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4441), new DateTime(2022, 5, 22, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4508), new DateTime(2021, 6, 6, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4511) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4512), new DateTime(2022, 7, 4, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4513) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4514), new DateTime(2022, 6, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4515) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4517), new DateTime(2022, 5, 12, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4519), new DateTime(2022, 5, 22, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4521), new DateTime(2022, 6, 26, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4523) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4524), new DateTime(2022, 5, 22, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4525) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4525), new DateTime(2022, 6, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4527), new DateTime(2022, 6, 21, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4529) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4529), new DateTime(2022, 5, 12, 10, 55, 24, 278, DateTimeKind.Utc).AddTicks(4530) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Freight",
                table: "Orders",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 138, DateTimeKind.Utc).AddTicks(8397), new DateTime(2022, 4, 2, 9, 55, 48, 138, DateTimeKind.Utc).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(168), new DateTime(2022, 5, 22, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(225) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(262), new DateTime(2021, 6, 6, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(265) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(267), new DateTime(2022, 7, 4, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(269), new DateTime(2022, 6, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(271), new DateTime(2022, 5, 12, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(274), new DateTime(2022, 5, 22, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(277), new DateTime(2022, 6, 26, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(279), new DateTime(2022, 5, 22, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(281), new DateTime(2022, 6, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(283), new DateTime(2022, 6, 21, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(286), new DateTime(2022, 5, 12, 9, 55, 48, 139, DateTimeKind.Utc).AddTicks(287) });
        }
    }
}
