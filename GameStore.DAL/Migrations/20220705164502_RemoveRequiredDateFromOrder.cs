using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveRequiredDateFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredDate",
                table: "Orders");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequiredDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(2927), new DateTime(2022, 3, 27, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4801), new DateTime(2022, 5, 16, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4906), new DateTime(2021, 5, 31, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4909) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4910), new DateTime(2022, 6, 28, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4913), new DateTime(2022, 6, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4914) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4915), new DateTime(2022, 5, 6, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4917), new DateTime(2022, 5, 16, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4919) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4920), new DateTime(2022, 6, 20, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4935), new DateTime(2022, 5, 16, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4937), new DateTime(2022, 6, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4939) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4940), new DateTime(2022, 6, 15, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4942), new DateTime(2022, 5, 6, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4943) });
        }
    }
}
