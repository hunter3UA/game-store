using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShipVia",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipPostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShipVia",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShipPostalCode",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(5398), new DateTime(2022, 3, 27, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(6999), new DateTime(2022, 5, 16, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7073), new DateTime(2021, 5, 31, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7077), new DateTime(2022, 6, 28, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7080), new DateTime(2022, 6, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7081) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7082), new DateTime(2022, 5, 6, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7083) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7084), new DateTime(2022, 5, 16, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7087), new DateTime(2022, 6, 20, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7088) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7089), new DateTime(2022, 5, 16, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7091), new DateTime(2022, 6, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7094), new DateTime(2022, 6, 15, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7095) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7096), new DateTime(2022, 5, 6, 16, 45, 1, 560, DateTimeKind.Utc).AddTicks(7097) });
        }
    }
}
