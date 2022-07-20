using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ExtendGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNorthwindGame",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(7728), new DateTime(2022, 3, 16, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9187), new DateTime(2022, 5, 5, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9296), new DateTime(2021, 5, 20, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9300), new DateTime(2022, 6, 17, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9302), new DateTime(2022, 5, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9305), new DateTime(2022, 4, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9308), new DateTime(2022, 5, 5, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9310), new DateTime(2022, 6, 9, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9313), new DateTime(2022, 5, 5, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9315), new DateTime(2022, 5, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9317), new DateTime(2022, 6, 4, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9319), new DateTime(2022, 4, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9321) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNorthwindGame",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 218, DateTimeKind.Utc).AddTicks(9791), new DateTime(2022, 3, 14, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(1885) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2394), new DateTime(2022, 5, 3, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2489), new DateTime(2021, 5, 18, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2493) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2495), new DateTime(2022, 6, 15, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2501), new DateTime(2022, 5, 23, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2502) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2504), new DateTime(2022, 4, 23, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2507), new DateTime(2022, 5, 3, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2509) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2510), new DateTime(2022, 6, 7, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2512) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2514), new DateTime(2022, 5, 3, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2517), new DateTime(2022, 5, 23, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2518) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2520), new DateTime(2022, 6, 2, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2653), new DateTime(2022, 4, 23, 7, 52, 4, 219, DateTimeKind.Utc).AddTicks(2655) });
        }
    }
}
