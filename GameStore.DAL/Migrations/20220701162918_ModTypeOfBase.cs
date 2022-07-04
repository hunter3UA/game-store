using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModTypeOfBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaseType",
                table: "Games",
                newName: "TypeOfBase");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(5109), new DateTime(2022, 3, 23, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6516), new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6569), new DateTime(2021, 5, 27, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6571) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6572), new DateTime(2022, 6, 24, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6575), new DateTime(2022, 6, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6577), new DateTime(2022, 5, 2, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6579), new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6581), new DateTime(2022, 6, 16, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6582) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6583), new DateTime(2022, 5, 12, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6585) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6585), new DateTime(2022, 6, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6587), new DateTime(2022, 6, 11, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6589) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6590), new DateTime(2022, 5, 2, 16, 29, 17, 881, DateTimeKind.Utc).AddTicks(6591) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfBase",
                table: "Games",
                newName: "BaseType");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(422), new DateTime(2022, 3, 23, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2243), new DateTime(2022, 5, 12, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2314), new DateTime(2021, 5, 27, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2317) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2319), new DateTime(2022, 6, 24, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2321), new DateTime(2022, 6, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2324), new DateTime(2022, 5, 2, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2326), new DateTime(2022, 5, 12, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2328) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2329), new DateTime(2022, 6, 16, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2331) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2332), new DateTime(2022, 5, 12, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2334), new DateTime(2022, 6, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2337), new DateTime(2022, 6, 11, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2338) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 1, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2339), new DateTime(2022, 5, 2, 16, 27, 23, 860, DateTimeKind.Utc).AddTicks(2341) });
        }
    }
}
