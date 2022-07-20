using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdatedB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNorthwindGame",
                table: "Games");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 911, DateTimeKind.Utc).AddTicks(8257), new DateTime(2022, 3, 20, 13, 51, 57, 911, DateTimeKind.Utc).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 911, DateTimeKind.Utc).AddTicks(9989), new DateTime(2022, 5, 9, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(73) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(83), new DateTime(2021, 5, 24, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(86), new DateTime(2022, 6, 21, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(88) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(89), new DateTime(2022, 5, 29, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(90) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(91), new DateTime(2022, 4, 29, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(93) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(94), new DateTime(2022, 5, 9, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(95) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(96), new DateTime(2022, 6, 13, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(97) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(98), new DateTime(2022, 5, 9, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(99) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(100), new DateTime(2022, 5, 29, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(102), new DateTime(2022, 6, 8, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(103) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 28, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(104), new DateTime(2022, 4, 29, 13, 51, 57, 912, DateTimeKind.Utc).AddTicks(105) });
        }
    }
}
