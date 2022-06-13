using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class EditGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3725));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedAt",
                value: new DateTime(2022, 6, 6, 17, 23, 13, 625, DateTimeKind.Utc).AddTicks(3726));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "Games");
        }
    }
}
