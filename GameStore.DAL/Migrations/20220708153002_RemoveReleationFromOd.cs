using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveReleationFromOd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Games_GameId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_GameId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(5335), new DateTime(2022, 3, 30, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7258), new DateTime(2022, 5, 19, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7345), new DateTime(2021, 6, 3, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7350), new DateTime(2022, 7, 1, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7352), new DateTime(2022, 6, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7355), new DateTime(2022, 5, 9, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7358), new DateTime(2022, 5, 19, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7360), new DateTime(2022, 6, 23, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7363), new DateTime(2022, 5, 19, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7365), new DateTime(2022, 6, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7368), new DateTime(2022, 6, 18, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 8, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7370), new DateTime(2022, 5, 9, 15, 30, 1, 656, DateTimeKind.Utc).AddTicks(7372) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_GameId",
                table: "OrderDetails",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Games_GameId",
                table: "OrderDetails",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
