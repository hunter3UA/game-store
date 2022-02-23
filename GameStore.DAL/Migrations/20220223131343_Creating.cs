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
                    fk_GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId1",
                        column: x => x.CommentId1,
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
                    { 15, "Adventure", null },
                    { 16, "Puzzle & Skill", null }
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("63b451fc-ec0c-4900-ab63-6c2148895da0"), "Mobile" },
                    { new Guid("e61d0043-d8a5-4f67-9c9d-188fef333cd4"), "Browser" },
                    { new Guid("789b89f2-b170-4b40-8e86-d08c8fa09923"), "Desktop" },
                    { new Guid("1e6e6b1a-386d-418b-a1e0-1476edb3592a"), "Console" }
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
                    { 13, "TPS", 11 },
                    { 14, "Misc", 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId1",
                table: "Comments",
                column: "CommentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_GameId",
                table: "Comments",
                column: "fk_GameId");

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
