using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateDateTimeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(4683), new DateTime(2022, 3, 17, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(5741) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(5980), new DateTime(2022, 5, 6, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6066), new DateTime(2021, 5, 21, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6068) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6070), new DateTime(2022, 6, 18, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6072), new DateTime(2022, 5, 26, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6074), new DateTime(2022, 4, 26, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6076), new DateTime(2022, 5, 6, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6078), new DateTime(2022, 6, 10, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6080), new DateTime(2022, 5, 6, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6081) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6082), new DateTime(2022, 5, 26, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6085), new DateTime(2022, 6, 5, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6086) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 25, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6087), new DateTime(2022, 4, 26, 15, 17, 44, 59, DateTimeKind.Utc).AddTicks(6088) });
        }
    }
}
