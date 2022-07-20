using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateInitialDataWithNorthwind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(5172), new DateTime(2022, 4, 6, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(6962) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7046), new DateTime(2022, 5, 26, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7139), new DateTime(2021, 6, 10, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7145), new DateTime(2022, 7, 8, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7149), new DateTime(2022, 6, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7153), new DateTime(2022, 5, 16, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7156), new DateTime(2022, 5, 26, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7158) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7160), new DateTime(2022, 6, 30, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7164), new DateTime(2022, 5, 26, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7167), new DateTime(2022, 6, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7171), new DateTime(2022, 6, 25, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7175), new DateTime(2022, 5, 16, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7176) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Publishers");

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
    }
}
