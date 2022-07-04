using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class AddTypeOfBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseType",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(422), new DateTime(2022, 3, 23, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2243), new DateTime(2022, 5, 12, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2314), new DateTime(2021, 5, 27, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2317) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2319), new DateTime(2022, 6, 24, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2321), new DateTime(2022, 6, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2324), new DateTime(2022, 5, 2, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2326), new DateTime(2022, 5, 12, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2328) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2329), new DateTime(2022, 6, 16, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2331) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2332), new DateTime(2022, 5, 12, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2334), new DateTime(2022, 6, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2337), new DateTime(2022, 6, 11, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2338) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2339), new DateTime(2022, 5, 2, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2341) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseType",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 854, DateTimeKind.Utc).AddTicks(9564), new DateTime(2022, 3, 23, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1213) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1683), new DateTime(2022, 5, 12, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1763), new DateTime(2021, 5, 27, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1768), new DateTime(2022, 6, 24, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1771), new DateTime(2022, 6, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1773) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1774), new DateTime(2022, 5, 2, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1776) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1778), new DateTime(2022, 5, 12, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1781), new DateTime(2022, 6, 16, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1783) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1784), new DateTime(2022, 5, 12, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1787), new DateTime(2022, 6, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1790), new DateTime(2022, 6, 11, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1793), new DateTime(2022, 5, 2, 13, 55, 24, 855, DateTimeKind.Utc).AddTicks(1795) });
        }
    }
}
