using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateOd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Games_ProductId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "GameKey",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 795, DateTimeKind.Utc).AddTicks(9365), new DateTime(2022, 3, 30, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(979), new DateTime(2022, 5, 19, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1047), new DateTime(2021, 6, 3, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1051), new DateTime(2022, 7, 1, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1054), new DateTime(2022, 6, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1056), new DateTime(2022, 5, 9, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1058), new DateTime(2022, 5, 19, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1060), new DateTime(2022, 6, 23, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1062), new DateTime(2022, 5, 19, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1064), new DateTime(2022, 6, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1066), new DateTime(2022, 6, 18, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1067) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1068), new DateTime(2022, 5, 9, 15, 22, 46, 796, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Games_GameId",
                table: "OrderDetails",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Games_GameId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "GameKey",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_GameId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Games_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
