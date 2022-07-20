using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfBase",
                table: "Games");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfBase",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(5335), new DateTime(2022, 3, 30, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7258), new DateTime(2022, 5, 19, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7345), new DateTime(2021, 6, 3, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7350), new DateTime(2022, 7, 1, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7352), new DateTime(2022, 6, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7355), new DateTime(2022, 5, 9, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7358), new DateTime(2022, 5, 19, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7360), new DateTime(2022, 6, 23, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7363), new DateTime(2022, 5, 19, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7365), new DateTime(2022, 6, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7368), new DateTime(2022, 6, 18, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7370), new DateTime(2022, 5, 9, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7372) });
        }
    }
}
