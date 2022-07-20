using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 128, DateTimeKind.Utc).AddTicks(3746), new DateTime(2022, 3, 30, 9, 14, 35, 128, DateTimeKind.Utc).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 128, DateTimeKind.Utc).AddTicks(9813), new DateTime(2022, 5, 19, 9, 14, 35, 128, DateTimeKind.Utc).AddTicks(9960) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(5), new DateTime(2021, 6, 3, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(12), new DateTime(2022, 7, 1, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(17) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(19), new DateTime(2022, 6, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(22) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(25), new DateTime(2022, 5, 9, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(28) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(30), new DateTime(2022, 5, 19, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(33) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(35), new DateTime(2022, 6, 23, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(40), new DateTime(2022, 5, 19, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(46) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(47), new DateTime(2022, 6, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(52), new DateTime(2022, 6, 18, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(57), new DateTime(2022, 5, 9, 9, 14, 35, 129, DateTimeKind.Utc).AddTicks(60) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(3711), new DateTime(2022, 3, 29, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6107), new DateTime(2022, 5, 18, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6206), new DateTime(2021, 6, 2, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6209) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6210), new DateTime(2022, 6, 30, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6213), new DateTime(2022, 6, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6216), new DateTime(2022, 5, 8, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6217) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6218), new DateTime(2022, 5, 18, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6221), new DateTime(2022, 6, 22, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6224), new DateTime(2022, 5, 18, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6227), new DateTime(2022, 6, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6229) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6281), new DateTime(2022, 6, 17, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6284) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 7, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6285), new DateTime(2022, 5, 8, 10, 57, 38, 863, DateTimeKind.Utc).AddTicks(6286) });
        }
    }
}
