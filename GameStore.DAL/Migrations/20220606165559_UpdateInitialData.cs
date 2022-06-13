using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Discontinued", "IsDeleted", "Key", "Name", "Price", "PublisherId", "UnitsInStock" },
                values: new object[,]
                {
                    { 7, "Description of nfs", false, false, "nfs", "Need for speed", 100m, 2, (short)5 },
                    { 9, "Description of Sea", false, false, "sea-of-thieves", "Sea of Thieves", 90m, 2, (short)5 },
                    { 11, "Description of Mass effect 1", false, false, "mass-effect-1", "Mass effect 1", 50m, 1, (short)5 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CompanyName", "Description", "HomePage", "IsDeleted" },
                values: new object[,]
                {
                    { 3, "Activision", "Desc of Activision", "Activision page", false },
                    { 4, "Firaxis", "Desc of Firaxis", "Firaxis page", false },
                    { 5, "Bohemia Interactive", "Desc of bohemia", "Bohemia page", false }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Discontinued", "IsDeleted", "Key", "Name", "Price", "PublisherId", "UnitsInStock" },
                values: new object[,]
                {
                    { 4, "Description of cmv", false, false, "call-of-duty-mv", "Call of Duty:MV", 30m, 3, (short)5 },
                    { 8, "Description of Sam", false, false, "serious-sam-4", "Serious Sam 4", 45m, 3, (short)5 },
                    { 12, "Description of Command and conqurer", false, false, "command-and-conqurer", "Command and conqurer", 150m, 3, (short)5 },
                    { 5, "Description of civ", false, false, "civiization-VI", "Sid Meier`s Civilization VI", 60m, 4, (short)5 },
                    { 10, "Description of Battlefield", false, false, "battlefield-4", "Battlefield 4", 100m, 4, (short)5 },
                    { 6, "Description of arma", false, false, "arma-3", "Arma 3", 80m, 5, (short)5 }
                });

            migrationBuilder.InsertData(
                table: "GenresInGames",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 7, 6 },
                    { 9, 14 },
                    { 11, 8 }
                });

            migrationBuilder.InsertData(
                table: "PlatformsInGames",
                columns: new[] { "GameId", "PlatformTypeId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 9, 4 },
                    { 11, 1 }
                });

            migrationBuilder.InsertData(
                table: "GenresInGames",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 4, 11 },
                    { 8, 12 },
                    { 12, 8 },
                    { 5, 3 },
                    { 10, 7 },
                    { 6, 11 }
                });

            migrationBuilder.InsertData(
                table: "PlatformsInGames",
                columns: new[] { "GameId", "PlatformTypeId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 8, 4 },
                    { 12, 2 },
                    { 5, 3 },
                    { 10, 2 },
                    { 6, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "GenresInGames",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 9, 14 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "PlatformsInGames",
                keyColumns: new[] { "GameId", "PlatformTypeId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
