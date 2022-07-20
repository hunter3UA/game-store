using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(2695), new DateTime(2022, 3, 6, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4175), new DateTime(2022, 4, 25, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4244), new DateTime(2021, 5, 10, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4247), new DateTime(2022, 6, 7, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4249), new DateTime(2022, 5, 15, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4310), new DateTime(2022, 4, 15, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4313), new DateTime(2022, 4, 25, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4315), new DateTime(2022, 5, 30, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4316) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4317), new DateTime(2022, 4, 25, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4319), new DateTime(2022, 5, 15, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4322), new DateTime(2022, 5, 25, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4324), new DateTime(2022, 4, 15, 8, 20, 37, 692, DateTimeKind.Utc).AddTicks(4325) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(8724), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9909), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9912), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9915), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9916), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9919), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9920), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9921), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 6, 14, 8, 7, 23, 588, DateTimeKind.Utc).AddTicks(9923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
