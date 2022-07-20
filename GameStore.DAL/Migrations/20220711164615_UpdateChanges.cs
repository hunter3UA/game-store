using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(3475), new DateTime(2022, 4, 2, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5033), new DateTime(2022, 5, 22, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5101), new DateTime(2021, 6, 6, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5105), new DateTime(2022, 7, 4, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5106) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5107), new DateTime(2022, 6, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5109) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5110), new DateTime(2022, 5, 12, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5112), new DateTime(2022, 5, 22, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5114), new DateTime(2022, 6, 26, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5115) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5116), new DateTime(2022, 5, 22, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5118), new DateTime(2022, 6, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5120), new DateTime(2022, 6, 21, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5121) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5122), new DateTime(2022, 5, 12, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5124) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
