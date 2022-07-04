using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class AddPublisherName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublisherName",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(865), new DateTime(2022, 3, 26, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2198), new DateTime(2022, 5, 15, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2286), new DateTime(2021, 5, 30, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2288) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2289), new DateTime(2022, 6, 27, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2293), new DateTime(2022, 6, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2295), new DateTime(2022, 5, 5, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2296) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2297), new DateTime(2022, 5, 15, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2299), new DateTime(2022, 6, 19, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2301) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2301), new DateTime(2022, 5, 15, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2302) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2303), new DateTime(2022, 6, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2305), new DateTime(2022, 6, 14, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2307), new DateTime(2022, 5, 5, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2308) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublisherName",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(5109), new DateTime(2022, 3, 23, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6516), new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6569), new DateTime(2021, 5, 27, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6571) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6572), new DateTime(2022, 6, 24, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6575), new DateTime(2022, 6, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6577), new DateTime(2022, 5, 2, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6579), new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6581), new DateTime(2022, 6, 16, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6582) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6583), new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6585) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6585), new DateTime(2022, 6, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6587), new DateTime(2022, 6, 11, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6589) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6590), new DateTime(2022, 5, 2, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6591) });
        }
    }
}
