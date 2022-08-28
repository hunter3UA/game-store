using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class AddTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "36a985c1-b496-4d9a-8333-aaea40ebc3ef");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4892ac46-f076-464d-8abf-c3d17700ce22");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8940be39-a642-43cf-8f3e-8233dee7f516");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "98a461f4-37a4-41bf-bf05-0559c7e9e012");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "aa740e0d-9b6f-456c-840b-dda5a5195eae");

            migrationBuilder.CreateTable(
                name: "GameTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
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
                name: "GenreTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "PlatformTypeTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(2594), new DateTime(2022, 5, 18, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4549) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4796), new DateTime(2022, 7, 7, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4883), new DateTime(2021, 7, 22, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4888), new DateTime(2022, 8, 19, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4892), new DateTime(2022, 7, 27, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4894) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4896), new DateTime(2022, 6, 27, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4897) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4899), new DateTime(2022, 7, 7, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4903), new DateTime(2022, 8, 11, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4905) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4907), new DateTime(2022, 7, 7, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4908) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4910), new DateTime(2022, 7, 27, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4911) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4913), new DateTime(2022, 8, 6, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4914) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 26, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4916), new DateTime(2022, 6, 27, 15, 31, 44, 718, DateTimeKind.Utc).AddTicks(4918) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "4dcd843d-a4d3-4677-882d-65e96596defb", "moderator@gmail.com", false, new byte[] { 33, 123, 57, 68, 136, 67, 96, 10, 153, 56, 225, 83, 78, 76, 43, 171, 93, 224, 171, 16, 221, 61, 51, 253, 27, 122, 60, 22, 173, 202, 219, 232, 34, 5, 193, 99, 152, 146, 205, 235, 59, 43, 138, 152, 124, 193, 226, 40, 51, 138, 138, 253, 233, 14, 41, 202, 15, 234, 161, 55, 127, 121, 136, 150 }, new byte[] { 140, 252, 26, 80, 100, 158, 205, 6, 235, 117, 160, 210, 74, 42, 125, 221, 163, 196, 145, 216, 76, 104, 242, 115 }, null, "Moderator", "moderator1" },
                    { "6178ad6a-b3d0-433b-81a6-ff78cc56b2a2", "manager1@gmail.com", false, new byte[] { 7, 175, 225, 161, 136, 235, 233, 186, 202, 216, 61, 34, 151, 51, 45, 100, 19, 109, 238, 118, 231, 57, 76, 136, 13, 119, 2, 86, 250, 161, 215, 153, 54, 191, 10, 152, 237, 197, 164, 15, 143, 161, 46, 76, 77, 116, 164, 187, 214, 46, 239, 191, 230, 19, 139, 206, 243, 166, 181, 117, 45, 71, 123, 197 }, new byte[] { 133, 82, 212, 28, 51, 92, 62, 18, 67, 148, 171, 144, 114, 123, 159, 156, 123, 100, 7, 223, 195, 31, 207, 196 }, null, "Manager", "manager1" },
                    { "427c92ca-7abe-4904-bab9-25f3e7ac9278", "user1@gmail.com", false, new byte[] { 174, 244, 223, 247, 255, 97, 155, 117, 146, 217, 57, 133, 207, 197, 123, 243, 44, 134, 149, 87, 20, 154, 191, 204, 115, 201, 226, 4, 157, 134, 183, 211, 170, 223, 85, 129, 164, 228, 231, 35, 176, 75, 205, 230, 153, 60, 115, 58, 13, 88, 182, 226, 157, 139, 6, 233, 140, 128, 30, 33, 214, 158, 44, 163 }, new byte[] { 40, 41, 82, 194, 101, 168, 178, 201, 193, 25, 146, 199, 130, 52, 134, 192, 21, 244, 30, 164, 18, 75, 200, 106 }, null, "User", "user1" },
                    { "48bf0be0-86c3-46df-a396-b9ae7321a8bb", "publisher1@gmail.com", false, new byte[] { 101, 226, 76, 100, 131, 158, 197, 251, 75, 246, 7, 95, 234, 124, 76, 186, 177, 65, 146, 53, 174, 198, 173, 123, 224, 46, 225, 87, 208, 53, 112, 214, 222, 147, 71, 255, 21, 34, 32, 91, 61, 104, 233, 221, 1, 161, 160, 36, 220, 18, 203, 4, 1, 97, 229, 237, 82, 20, 230, 138, 84, 66, 206, 62 }, new byte[] { 178, 8, 19, 255, 241, 244, 51, 151, 195, 208, 192, 214, 121, 176, 93, 122, 172, 255, 233, 187, 6, 248, 209, 58 }, "DeepSilver", "Publisher", "publisher1" },
                    { "76ad8df7-bdce-4244-9127-74373bb675dc", "admin@gmail.com", false, new byte[] { 247, 86, 224, 107, 88, 243, 146, 140, 10, 64, 171, 204, 162, 101, 45, 25, 125, 42, 227, 26, 25, 90, 15, 153, 120, 197, 130, 34, 151, 206, 9, 185, 86, 81, 29, 35, 120, 178, 227, 185, 221, 162, 47, 145, 74, 12, 114, 41, 197, 161, 127, 70, 250, 1, 189, 179, 175, 65, 198, 41, 125, 112, 8, 32 }, new byte[] { 152, 73, 12, 238, 187, 217, 217, 185, 123, 241, 27, 212, 95, 97, 122, 12, 251, 205, 30, 115, 89, 167, 148, 34 }, null, "Admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTranslates_GameId",
                table: "GameTranslates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreTranslates_GenreId",
                table: "GenreTranslates",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformTypeTranslates_PlatformTypeId",
                table: "PlatformTypeTranslates",
                column: "PlatformTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PublisherTranslates_PublisherId",
                table: "PublisherTranslates",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTranslates");

            migrationBuilder.DropTable(
                name: "GenreTranslates");

            migrationBuilder.DropTable(
                name: "PlatformTypeTranslates");

            migrationBuilder.DropTable(
                name: "PublisherTranslates");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "427c92ca-7abe-4904-bab9-25f3e7ac9278");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "48bf0be0-86c3-46df-a396-b9ae7321a8bb");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4dcd843d-a4d3-4677-882d-65e96596defb");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6178ad6a-b3d0-433b-81a6-ff78cc56b2a2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "76ad8df7-bdce-4244-9127-74373bb675dc");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(1410), new DateTime(2022, 5, 10, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3513), new DateTime(2022, 6, 29, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3594), new DateTime(2021, 7, 14, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3597) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3599), new DateTime(2022, 8, 11, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3602), new DateTime(2022, 7, 19, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3606), new DateTime(2022, 6, 19, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3610), new DateTime(2022, 6, 29, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3614), new DateTime(2022, 8, 3, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3617), new DateTime(2022, 6, 29, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3620), new DateTime(2022, 7, 19, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3621) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3623), new DateTime(2022, 7, 29, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 18, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3626), new DateTime(2022, 6, 19, 13, 40, 48, 140, DateTimeKind.Utc).AddTicks(3628) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "98a461f4-37a4-41bf-bf05-0559c7e9e012", "moderator@gmail.com", false, new byte[] { 10, 241, 88, 1, 28, 22, 83, 9, 93, 101, 179, 20, 209, 130, 43, 182, 235, 191, 8, 128, 11, 199, 245, 164, 135, 202, 5, 210, 157, 219, 4, 16, 164, 84, 9, 155, 67, 41, 171, 158, 252, 2, 121, 165, 226, 147, 229, 212, 138, 132, 244, 124, 27, 70, 35, 166, 20, 3, 44, 127, 245, 141, 241, 161 }, new byte[] { 228, 11, 86, 193, 29, 179, 38, 9, 210, 177, 196, 89, 113, 5, 207, 46, 151, 174, 164, 219, 51, 15, 230, 6 }, null, "Moderator", "moderator1" },
                    { "aa740e0d-9b6f-456c-840b-dda5a5195eae", "manager1@gmail.com", false, new byte[] { 152, 97, 139, 63, 226, 119, 78, 40, 109, 117, 80, 5, 189, 60, 44, 155, 143, 173, 80, 211, 142, 168, 41, 117, 169, 250, 199, 151, 215, 96, 19, 16, 150, 28, 100, 225, 63, 152, 94, 193, 213, 71, 8, 203, 159, 137, 249, 160, 105, 176, 172, 146, 211, 68, 28, 75, 212, 15, 235, 3, 141, 176, 78, 148 }, new byte[] { 98, 33, 93, 14, 216, 77, 166, 151, 198, 81, 156, 181, 58, 150, 10, 254, 128, 121, 152, 242, 24, 31, 183, 227 }, null, "Manager", "manager1" },
                    { "36a985c1-b496-4d9a-8333-aaea40ebc3ef", "user1@gmail.com", false, new byte[] { 0, 193, 67, 80, 65, 9, 40, 156, 101, 48, 151, 19, 129, 198, 122, 245, 227, 180, 40, 45, 158, 200, 113, 112, 171, 161, 211, 38, 214, 236, 63, 34, 7, 109, 93, 170, 160, 142, 56, 242, 43, 227, 49, 249, 84, 250, 76, 199, 95, 57, 224, 126, 176, 124, 172, 66, 206, 238, 95, 152, 179, 247, 142, 57 }, new byte[] { 58, 160, 68, 70, 48, 106, 6, 123, 41, 250, 214, 235, 183, 139, 45, 186, 167, 18, 132, 141, 19, 148, 84, 154 }, null, "User", "user1" },
                    { "4892ac46-f076-464d-8abf-c3d17700ce22", "publisher1@gmail.com", false, new byte[] { 203, 152, 135, 38, 46, 31, 88, 224, 186, 119, 173, 13, 227, 208, 246, 246, 133, 48, 163, 223, 184, 147, 144, 190, 4, 207, 79, 43, 15, 205, 55, 40, 125, 90, 154, 224, 181, 108, 122, 47, 163, 32, 210, 130, 175, 0, 84, 23, 135, 43, 150, 16, 8, 74, 36, 0, 186, 60, 192, 4, 169, 211, 253, 61 }, new byte[] { 233, 250, 170, 151, 160, 217, 218, 34, 219, 175, 222, 170, 200, 75, 241, 80, 245, 163, 136, 217, 229, 42, 129, 48 }, "DeepSilver", "Publisher", "publisher1" },
                    { "8940be39-a642-43cf-8f3e-8233dee7f516", "admin@gmail.com", false, new byte[] { 18, 27, 201, 111, 222, 138, 18, 116, 137, 46, 119, 44, 245, 251, 150, 196, 17, 199, 159, 75, 11, 210, 168, 183, 227, 17, 243, 201, 75, 1, 143, 154, 232, 19, 2, 6, 9, 162, 90, 201, 136, 142, 146, 161, 243, 48, 71, 136, 56, 27, 91, 54, 64, 21, 227, 135, 71, 237, 41, 79, 211, 57, 174, 25 }, new byte[] { 186, 191, 152, 2, 137, 119, 71, 176, 109, 27, 175, 178, 23, 146, 93, 166, 105, 169, 104, 224, 99, 177, 122, 194 }, null, "Admin", "admin" }
                });
        }
    }
}
