using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class Creating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfViews = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitsOnOrder = table.Column<int>(type: "int", nullable: false),
                    ReorderLevel = table.Column<int>(type: "int", nullable: false),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentGenreId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Genres_ParentGenreId",
                        column: x => x.ParentGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipperCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "ntext", maxLength: 1000, nullable: true),
                    HomePage = table.Column<string>(type: "ntext", maxLength: 400, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    IsQuote = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTranslates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenresInGames",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresInGames", x => new { x.GenreId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GenresInGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenresInGames_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreTranslates_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsInGames",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsInGames", x => new { x.PlatformTypeId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlatformsInGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformsInGames_PlatformTypes_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "PlatformTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformTypeTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformTypeTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformTypeTranslates_PlatformTypes_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "PlatformTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublisherTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublisherTranslates_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AddedAt", "Description", "Discontinued", "IsDeleted", "Key", "Name", "NumberOfViews", "Price", "PublishedAt", "PublisherName", "QuantityPerUnit", "ReorderLevel", "UnitsInStock", "UnitsOnOrder" },
                values: new object[,]
                {
                    { 12, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1755), "Description of Command and conqurer", false, false, "command-and-conqurer", "Command and conqurer", 0, 150m, new DateTime(2022, 11, 13, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1757), "Activision", null, 0, (short)5, 0 },
                    { 11, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1754), "Description of Mass effect 1", false, false, "mass-effect-1", "Mass effect 1", 0, 50m, new DateTime(2022, 12, 23, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1755), "DeepSiler", null, 0, (short)5, 0 },
                    { 10, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1752), "Description of Battlefield", false, false, "battlefield-4", "Battlefield 4", 0, 100m, new DateTime(2022, 12, 13, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1753), "Firaxis", null, 0, (short)5, 0 },
                    { 8, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1747), "Description of Sam", false, false, "serious-sam-4", "Serious Sam 4", 0, 45m, new DateTime(2022, 12, 28, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1749), "Activision", null, 0, (short)5, 0 },
                    { 7, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1745), "Description of nfs", false, false, "nfs", "Need for speed", 0, 100m, new DateTime(2022, 11, 23, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1746), "GSC", null, 0, (short)5, 0 },
                    { 6, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1742), "Description of arma", false, false, "arma-3", "Arma 3", 0, 80m, new DateTime(2022, 11, 13, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1744), "Bohemia Interactive", null, 0, (short)5, 0 },
                    { 5, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1740), "Description of civ", false, false, "civiization-VI", "Sid Meier`s Civilization VI", 0, 60m, new DateTime(2022, 12, 13, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1741), "Firaxis", null, 0, (short)5, 0 },
                    { 4, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1738), "Description of cmv", false, false, "call-of-duty-mv", "Call of Duty:MV", 0, 30m, new DateTime(2023, 1, 5, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1739), "Activision", null, 0, (short)5, 0 },
                    { 9, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1750), "Description of Sea", false, false, "sea-of-thieves", "Sea of Thieves", 0, 90m, new DateTime(2022, 11, 23, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1751), "GSC", null, 0, (short)5, 0 },
                    { 2, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1654), "Best part", false, false, "dying-light", "Dying light", 0, 50m, new DateTime(2022, 11, 23, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1716), "DeepSiler", null, 0, (short)0, 0 },
                    { 1, new DateTime(2023, 1, 12, 18, 16, 47, 731, DateTimeKind.Utc).AddTicks(9662), "New part of Stalker", false, false, "stalker-2", "Stalker2", 0, 70m, new DateTime(2022, 10, 4, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1338), "GSC", null, 0, (short)10, 0 },
                    { 3, new DateTime(2023, 1, 12, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1734), "Action ", false, false, "left-4-dead", "Left 4 Dead", 0, 100m, new DateTime(2021, 12, 8, 18, 16, 47, 732, DateTimeKind.Utc).AddTicks(1736), "GSC", null, 0, (short)3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CategoryId", "Description", "IsDeleted", "Name", "ParentGenreId" },
                values: new object[,]
                {
                    { 16, null, null, false, "Misc", null },
                    { 15, null, null, false, "Puzzle & Skill", null },
                    { 14, null, null, false, "Adventure", null },
                    { 11, null, null, false, "Action", null },
                    { 6, null, null, false, "Races", null },
                    { 5, null, null, false, "Sports", null },
                    { 1, null, null, false, "Strategy", null },
                    { 4, null, null, false, "RPG", null }
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "Id", "IsDeleted", "Type" },
                values: new object[,]
                {
                    { 3, false, "Desktop" },
                    { 1, false, "Mobile" },
                    { 4, false, "Console" },
                    { 2, false, "Browser" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "City", "CompanyName", "ContactName", "ContactTitle", "Country", "Description", "Fax", "HomePage", "IsDeleted", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 3, null, null, "Activision", null, null, null, "Desc of Activision", null, "Activision page", false, null, null, null },
                    { 2, null, null, "GSC", null, null, null, "Desc of Publisher 2 ", null, "Home2", false, null, null, null },
                    { 1, null, null, "DeepSilver", null, null, null, "Desc of Publisher 1 ", null, "Home", false, null, null, null },
                    { 5, null, null, "Bohemia Interactive", null, null, null, "Desc of bohemia", null, "Bohemia page", false, null, null, null },
                    { 4, null, null, "Firaxis", null, null, null, "Desc of Firaxis", null, "Firaxis page", false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "facee451-4656-47c0-a548-9633e422eef4", "publisher1@gmail.com", false, new byte[] { 235, 56, 94, 74, 130, 52, 251, 24, 116, 213, 170, 238, 17, 113, 16, 130, 28, 3, 204, 191, 142, 249, 101, 232, 27, 117, 169, 220, 237, 121, 166, 47, 71, 208, 252, 223, 16, 143, 73, 193, 168, 107, 11, 16, 121, 97, 116, 157, 239, 50, 141, 178, 104, 221, 253, 130, 164, 245, 194, 167, 119, 238, 133, 55 }, new byte[] { 92, 32, 101, 18, 57, 220, 245, 237, 35, 79, 104, 98, 47, 21, 235, 99, 126, 165, 175, 72, 250, 10, 176, 205 }, "DeepSilver", "Publisher", "publisher1" },
                    { "b031fa0c-d749-4b5b-976f-917e47bc4d07", "moderator@gmail.com", false, new byte[] { 97, 206, 209, 185, 48, 185, 146, 27, 223, 123, 165, 15, 203, 49, 70, 151, 82, 53, 19, 47, 109, 105, 105, 72, 81, 30, 214, 87, 186, 109, 179, 17, 38, 185, 225, 107, 55, 66, 237, 112, 28, 134, 12, 103, 222, 173, 63, 72, 95, 7, 27, 130, 27, 42, 158, 135, 14, 3, 196, 107, 86, 60, 250, 195 }, new byte[] { 219, 69, 192, 163, 132, 250, 186, 250, 23, 56, 29, 58, 207, 155, 231, 67, 142, 7, 13, 232, 183, 236, 4, 200 }, null, "Moderator", "moderator1" },
                    { "48a82a96-ed6d-4fe6-86cd-256d234f1c6d", "manager1@gmail.com", false, new byte[] { 70, 143, 105, 35, 208, 222, 36, 165, 12, 139, 94, 145, 227, 87, 3, 30, 15, 115, 137, 164, 193, 21, 120, 179, 104, 124, 233, 233, 138, 185, 126, 110, 124, 234, 46, 87, 222, 4, 18, 144, 88, 156, 80, 157, 226, 204, 130, 241, 101, 34, 90, 245, 133, 112, 151, 141, 126, 74, 21, 21, 194, 252, 115, 5 }, new byte[] { 25, 100, 247, 108, 228, 62, 254, 195, 52, 4, 135, 89, 11, 66, 149, 163, 13, 229, 253, 228, 62, 181, 160, 232 }, null, "Manager", "manager1" },
                    { "44a14fd2-9bdc-46d7-a668-e05bd64dfa50", "user1@gmail.com", false, new byte[] { 57, 96, 139, 16, 217, 243, 206, 27, 173, 192, 239, 134, 113, 100, 244, 86, 25, 21, 46, 201, 242, 79, 107, 191, 136, 195, 78, 144, 236, 77, 39, 240, 7, 175, 141, 116, 97, 158, 150, 14, 151, 195, 97, 115, 142, 117, 238, 40, 28, 151, 72, 139, 87, 4, 93, 66, 40, 201, 51, 76, 22, 140, 159, 48 }, new byte[] { 67, 150, 174, 138, 248, 147, 118, 2, 237, 27, 57, 126, 202, 25, 81, 188, 234, 199, 158, 67, 42, 255, 83, 138 }, null, "User", "user1" },
                    { "32fd1330-40aa-4cf5-ada5-1f87ea6d9235", "admin@gmail.com", false, new byte[] { 134, 225, 45, 85, 67, 72, 110, 153, 217, 187, 167, 183, 184, 54, 116, 138, 203, 72, 190, 2, 78, 184, 194, 195, 1, 58, 246, 224, 192, 8, 97, 206, 229, 96, 62, 174, 188, 58, 82, 1, 159, 93, 85, 146, 170, 216, 147, 241, 209, 169, 140, 165, 181, 60, 169, 132, 131, 226, 48, 192, 211, 164, 163, 203 }, new byte[] { 18, 34, 192, 228, 116, 97, 233, 189, 252, 135, 105, 36, 216, 59, 151, 184, 144, 13, 216, 8, 192, 100, 124, 204 }, null, "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CategoryId", "Description", "IsDeleted", "Name", "ParentGenreId" },
                values: new object[,]
                {
                    { 2, null, null, false, "RTS", 1 },
                    { 3, null, null, false, "TBS", 1 },
                    { 13, null, null, false, "TPS", 11 },
                    { 12, null, null, false, "FPS", 11 },
                    { 7, null, null, false, "Rally", 6 },
                    { 8, null, null, false, "Arcade", 6 },
                    { 9, null, null, false, "Formula", 6 },
                    { 10, null, null, false, "Off-road", 6 }
                });

            migrationBuilder.InsertData(
                table: "GenresInGames",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 11 },
                    { 9, 14 },
                    { 7, 6 },
                    { 3, 5 },
                    { 4, 11 }
                });

            migrationBuilder.InsertData(
                table: "PlatformsInGames",
                columns: new[] { "GameId", "PlatformTypeId" },
                values: new object[,]
                {
                    { 8, 4 },
                    { 1, 1 },
                    { 7, 1 },
                    { 11, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 10, 2 },
                    { 12, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 3, 4 },
                    { 9, 4 }
                });

            migrationBuilder.InsertData(
                table: "GenresInGames",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 5, 3 },
                    { 10, 7 },
                    { 11, 8 },
                    { 12, 8 },
                    { 8, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GameId",
                table: "Comments",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Key",
                table: "Games",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameTranslates_GameId",
                table: "GameTranslates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ParentGenreId",
                table: "Genres",
                column: "ParentGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresInGames_GameId",
                table: "GenresInGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreTranslates_GenreId",
                table: "GenreTranslates",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsInGames_GameId",
                table: "PlatformsInGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformTypes_Type",
                table: "PlatformTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformTypeTranslates_PlatformTypeId",
                table: "PlatformTypeTranslates",
                column: "PlatformTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_CompanyName",
                table: "Publishers",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublisherTranslates_PublisherId",
                table: "PublisherTranslates",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GameTranslates");

            migrationBuilder.DropTable(
                name: "GenresInGames");

            migrationBuilder.DropTable(
                name: "GenreTranslates");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PlatformsInGames");

            migrationBuilder.DropTable(
                name: "PlatformTypeTranslates");

            migrationBuilder.DropTable(
                name: "PublisherTranslates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlatformTypes");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
