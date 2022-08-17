using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(5221), new DateTime(2022, 4, 23, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8260), new DateTime(2022, 6, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8378), new DateTime(2021, 6, 27, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8386), new DateTime(2022, 7, 25, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8391), new DateTime(2022, 7, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8396), new DateTime(2022, 6, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8401), new DateTime(2022, 6, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8449) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8452), new DateTime(2022, 7, 17, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8455) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8458), new DateTime(2022, 6, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8462), new DateTime(2022, 7, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8465) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8468), new DateTime(2022, 7, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8474), new DateTime(2022, 6, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8476) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(3514), new DateTime(2022, 4, 19, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6615), new DateTime(2022, 6, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6737), new DateTime(2021, 6, 23, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6744), new DateTime(2022, 7, 21, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6749), new DateTime(2022, 6, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6754), new DateTime(2022, 5, 29, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6756) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6759), new DateTime(2022, 6, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6764), new DateTime(2022, 7, 13, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6862), new DateTime(2022, 6, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6868), new DateTime(2022, 6, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6873), new DateTime(2022, 7, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6878), new DateTime(2022, 5, 29, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CategoryId", "Description", "IsDeleted", "Name", "ParentGenreId" },
                values: new object[,]
                {
                    { 23, 7, "Dried fruit and bean curd", false, "Produce", null },
                    { 22, 6, "Prepared meats", false, "Meat/Poultry", null },
                    { 21, 5, "Breads, crackers, pasta, and cereal", false, "Grains/Cereals", null },
                    { 20, 4, "Cheeses", false, "Dairy Products", null },
                    { 19, 3, "Desserts, candies, and sweet breads", false, "Confections", null },
                    { 18, 2, "Sweet and savory sauces, relishes, spreads, and seasonings", false, "Condiments", null },
                    { 24, 8, "Seaweed and fish", false, "Seafood", null },
                    { 17, 1, "Soft drinks, coffees, teas, beers, and ales", false, "Beverages", null }
                });
        }
    }
}
