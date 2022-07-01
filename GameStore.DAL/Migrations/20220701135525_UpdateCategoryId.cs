using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Genres",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Genres");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 39, DateTimeKind.Utc).AddTicks(8794), new DateTime(2022, 3, 22, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(493), new DateTime(2022, 5, 11, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(566), new DateTime(2021, 5, 26, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(569) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(570), new DateTime(2022, 6, 23, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(573), new DateTime(2022, 5, 31, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(574) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(575), new DateTime(2022, 5, 1, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(577), new DateTime(2022, 5, 11, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(578) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(579), new DateTime(2022, 6, 15, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(583), new DateTime(2022, 5, 11, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(585), new DateTime(2022, 5, 31, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(587), new DateTime(2022, 6, 10, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(589), new DateTime(2022, 5, 1, 15, 51, 48, 40, DateTimeKind.Utc).AddTicks(591) });
        }
    }
}
