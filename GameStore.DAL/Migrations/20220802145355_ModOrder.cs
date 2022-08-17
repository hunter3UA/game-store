using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(4330), new DateTime(2022, 4, 24, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6099) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6345), new DateTime(2022, 6, 13, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6432) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6443), new DateTime(2021, 6, 28, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6446) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6448), new DateTime(2022, 7, 26, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6452), new DateTime(2022, 7, 3, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6453) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6455), new DateTime(2022, 6, 3, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6457) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6459), new DateTime(2022, 6, 13, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6462), new DateTime(2022, 7, 18, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6463) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6465), new DateTime(2022, 6, 13, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6466) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6468), new DateTime(2022, 7, 3, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6472), new DateTime(2022, 7, 13, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6473) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6475), new DateTime(2022, 6, 3, 14, 53, 55, 242, DateTimeKind.Utc).AddTicks(6476) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(6117), new DateTime(2022, 4, 24, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(7993) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8278), new DateTime(2022, 6, 13, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8388), new DateTime(2021, 6, 28, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8393), new DateTime(2022, 7, 26, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8394) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8396), new DateTime(2022, 7, 3, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8400), new DateTime(2022, 6, 3, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8403), new DateTime(2022, 6, 13, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8406), new DateTime(2022, 7, 18, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8408) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8410), new DateTime(2022, 6, 13, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8413), new DateTime(2022, 7, 3, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8416), new DateTime(2022, 7, 13, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8418) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8419), new DateTime(2022, 6, 3, 13, 41, 39, 586, DateTimeKind.Utc).AddTicks(8421) });
        }
    }
}
