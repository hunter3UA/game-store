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
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fk_ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Genres_fk_ParentId",
                        column: x => x.fk_ParentId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatformTypes",
                columns: table => new
                {
                    PlatformTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformTypes", x => x.PlatformTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fk_ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fk_GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_fk_ParentId",
                        column: x => x.fk_ParentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Games_fk_GameId",
                        column: x => x.fk_GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    GamesGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenresGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => new { x.GamesGameId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_GameGenres_Games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    GamesGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformTypesPlatformTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => new { x.GamesGameId, x.PlatformTypesPlatformTypeId });
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_PlatformTypes_PlatformTypesPlatformTypeId",
                        column: x => x.PlatformTypesPlatformTypeId,
                        principalTable: "PlatformTypes",
                        principalColumn: "PlatformTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name", "fk_ParentId" },
                values: new object[,]
                {
                    { 1, "Strategy", null },
                    { 4, "RPG", null },
                    { 5, "Sports", null },
                    { 6, "Races", null },
                    { 11, "Action", null },
                    { 14, "Adventure", null },
                    { 15, "Puzzle & Skill", null },
                    { 16, "Misc", null }
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("6296ed25-ddb8-43fa-8e52-c81e73eb4d3f"), "Mobile" },
                    { new Guid("d3badeee-0a8c-4069-801a-b1c1020bc00b"), "Browser" },
                    { new Guid("10e48462-d5c0-4686-8fdc-94f39beed2cb"), "Desktop" },
                    { new Guid("27754cdf-3662-4437-a9e5-daa31a700b98"), "Console" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name", "fk_ParentId" },
                values: new object[,]
                {
                    { 2, "RTS", 1 },
                    { 3, "TBS", 1 },
                    { 7, "Rally", 6 },
                    { 8, "Arcade", 6 },
                    { 9, "Formula", 6 },
                    { 10, "Off-road", 6 },
                    { 12, "FPS", 11 },
                    { 13, "TPS", 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_GameId",
                table: "Comments",
                column: "fk_GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_ParentId",
                table: "Comments",
                column: "fk_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GenresGenreId",
                table: "GameGenres",
                column: "GenresGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_PlatformTypesPlatformTypeId",
                table: "GamePlatforms",
                column: "PlatformTypesPlatformTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_fk_ParentId",
                table: "Genres",
                column: "fk_ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformTypes_Type",
                table: "PlatformTypes",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlatformTypes");
        }
    }
}
