using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModOrdersShippedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShippedDate",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(7728), new DateTime(2022, 3, 16, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9187), new DateTime(2022, 5, 5, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9296), new DateTime(2021, 5, 20, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9300), new DateTime(2022, 6, 17, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9302), new DateTime(2022, 5, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9305), new DateTime(2022, 4, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9308), new DateTime(2022, 5, 5, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9310), new DateTime(2022, 6, 9, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9313), new DateTime(2022, 5, 5, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9315), new DateTime(2022, 5, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9317), new DateTime(2022, 6, 4, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 24, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9319), new DateTime(2022, 4, 25, 17, 51, 53, 749, DateTimeKind.Utc).AddTicks(9321) });
        }
    }
}
