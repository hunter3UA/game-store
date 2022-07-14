using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdatePriceOfDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(2506), new DateTime(2022, 4, 5, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3778) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3919), new DateTime(2022, 5, 25, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3982) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3987), new DateTime(2021, 6, 9, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3991), new DateTime(2022, 7, 7, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3993) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3995), new DateTime(2022, 6, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3998), new DateTime(2022, 5, 15, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(3999) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4001), new DateTime(2022, 5, 25, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4004), new DateTime(2022, 6, 29, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4007), new DateTime(2022, 5, 25, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4010), new DateTime(2022, 6, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4013), new DateTime(2022, 6, 24, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4017), new DateTime(2022, 5, 15, 8, 8, 17, 884, DateTimeKind.Utc).AddTicks(4018) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 392, DateTimeKind.Utc).AddTicks(8303), new DateTime(2022, 4, 3, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(292) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(738), new DateTime(2022, 5, 23, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(851), new DateTime(2021, 6, 7, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(857), new DateTime(2022, 7, 5, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(861), new DateTime(2022, 6, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(865), new DateTime(2022, 5, 13, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(868), new DateTime(2022, 5, 23, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(871), new DateTime(2022, 6, 27, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(873) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(874), new DateTime(2022, 5, 23, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(877), new DateTime(2022, 6, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(881), new DateTime(2022, 6, 22, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(884), new DateTime(2022, 5, 13, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(886) });
        }
    }
}
