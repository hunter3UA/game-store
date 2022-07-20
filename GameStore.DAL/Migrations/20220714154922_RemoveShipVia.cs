using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveShipVia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipVia",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShipperCompanyName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(8407), new DateTime(2022, 4, 5, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9766), new DateTime(2022, 5, 25, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9828) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9833), new DateTime(2021, 6, 9, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9838), new DateTime(2022, 7, 7, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9839) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9841), new DateTime(2022, 6, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9842) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9844), new DateTime(2022, 5, 15, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9847), new DateTime(2022, 5, 25, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9848) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9850), new DateTime(2022, 6, 29, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9851) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9852), new DateTime(2022, 5, 25, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9853) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9855), new DateTime(2022, 6, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9856) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9858), new DateTime(2022, 6, 24, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 14, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9861), new DateTime(2022, 5, 15, 15, 49, 21, 676, DateTimeKind.Utc).AddTicks(9913) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipperCompanyName",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ShipVia",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
