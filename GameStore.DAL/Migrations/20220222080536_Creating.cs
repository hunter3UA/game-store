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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
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
                    Level = table.Column<int>(type: "int", nullable: false),
                    IsAnsweread = table.Column<bool>(type: "bit", nullable: false),
                    AnswerTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
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
                name: "SubGenres",
                columns: table => new
                {
                    SubGenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fk_GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenres", x => x.SubGenreId);
                    table.ForeignKey(
                        name: "FK_SubGenres_Genres_fk_GenreId",
                        column: x => x.fk_GenreId,
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
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Strategy" },
                    { 2, "Sports" },
                    { 3, "Races" },
                    { 4, "Action" },
                    { 5, "RPG" },
                    { 6, "Adventure" },
                    { 7, "Puzzle & Skill" },
                    { 8, "Misc" }
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("e18dc0f8-8abc-46d7-a01b-12f273c4be63"), "Mobile" },
                    { new Guid("8dab9097-6e14-414f-8f13-a21f85ce0508"), "Browser" },
                    { new Guid("6419d2b5-0618-4994-b806-f513e816ba69"), "Desktop" },
                    { new Guid("726a9430-cd7f-4a04-b0c2-9a9fce1d2170"), "Console" }
                });

            migrationBuilder.InsertData(
                table: "SubGenres",
                columns: new[] { "SubGenreId", "fk_GenreId", "Name" },
                values: new object[,]
                {
                    { new Guid("39559fed-4aeb-4ddc-a5a1-6b29d746da15"), 1, "RTS" },
                    { new Guid("c6286a1e-7e90-4c0f-96f7-b40cab1f284b"), 1, "TBS" },
                    { new Guid("6afa17d0-8813-4368-b31b-54c1fffed5e4"), 3, "Rally" },
                    { new Guid("f869bbb9-8b03-4661-b838-d1bbedd0e6be"), 3, "Arcade" },
                    { new Guid("c4f0c6d2-edfb-4a49-b0af-f1a3a8a7ccaa"), 3, "Formula" },
                    { new Guid("76cf924c-feda-4284-b927-d661986cf8b2"), 3, "Off-road" },
                    { new Guid("790b7ca4-2d54-4e02-a073-8cf9753a1d04"), 4, "FPS" },
                    { new Guid("4faad84a-170e-4cbe-b78d-07d912d017eb"), 4, "TPS" },
                    { new Guid("11b9888d-cfcf-45f0-ac55-65b5729e69cd"), 4, "Misc" }
                });

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
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformTypes_Type",
                table: "PlatformTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubGenres_fk_GenreId",
                table: "SubGenres",
                column: "fk_GenreId");
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
                name: "SubGenres");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlatformTypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
