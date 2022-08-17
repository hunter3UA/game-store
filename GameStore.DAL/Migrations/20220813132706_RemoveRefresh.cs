using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveRefresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "08e61602-3a78-4676-bd53-b1269acf7de4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0d65ef75-a268-45bb-9f3f-5e551be85669");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1ad744c5-ab8b-4f48-a4b3-9fa839e97f9b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8364e9b9-1ed4-403c-bc8a-f37b53c31454");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "db098567-071c-49d5-b569-093a809ab699");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(2533), new DateTime(2022, 5, 5, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4272) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4519), new DateTime(2022, 6, 24, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4664), new DateTime(2021, 7, 9, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4667) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4669), new DateTime(2022, 8, 6, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4673), new DateTime(2022, 7, 14, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4676), new DateTime(2022, 6, 14, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4678) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4680), new DateTime(2022, 6, 24, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4681) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4683), new DateTime(2022, 7, 29, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4718), new DateTime(2022, 6, 24, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4722), new DateTime(2022, 7, 14, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4725), new DateTime(2022, 7, 24, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 13, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4729), new DateTime(2022, 6, 14, 13, 27, 5, 799, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "b98f612b-cef3-4978-bed6-2930cff0d367", "moderator@gmail.com", false, new byte[] { 46, 229, 35, 168, 165, 59, 234, 35, 91, 123, 171, 242, 240, 37, 22, 77, 161, 215, 232, 109, 240, 124, 236, 163, 181, 170, 214, 112, 234, 17, 184, 181, 48, 196, 61, 180, 15, 102, 92, 51, 148, 54, 123, 69, 105, 112, 230, 143, 204, 240, 67, 247, 138, 161, 173, 136, 158, 51, 138, 80, 220, 196, 22, 200 }, new byte[] { 243, 187, 190, 159, 127, 76, 129, 171, 127, 94, 95, 53, 92, 112, 101, 10, 67, 75, 114, 151, 34, 132, 215, 249 }, null, "Moderator", "moderator1" },
                    { "1437c530-183c-44ec-88aa-05481dfd38e1", "manager1@gmail.com", false, new byte[] { 60, 67, 97, 10, 149, 208, 227, 226, 139, 102, 70, 61, 66, 127, 22, 152, 117, 125, 7, 60, 76, 121, 165, 45, 121, 219, 119, 106, 33, 198, 8, 254, 37, 25, 186, 45, 123, 112, 19, 168, 80, 194, 5, 13, 18, 219, 244, 40, 66, 141, 5, 87, 39, 207, 175, 206, 39, 255, 180, 49, 166, 60, 113, 97 }, new byte[] { 105, 104, 181, 152, 47, 147, 178, 246, 236, 236, 80, 38, 225, 177, 189, 245, 103, 77, 41, 93, 70, 57, 40, 151 }, null, "Manager", "manager1" },
                    { "5343b58b-a88e-4e6c-b191-8c3c3cf85c82", "user1@gmail.com", false, new byte[] { 118, 90, 56, 77, 248, 56, 174, 239, 109, 0, 94, 2, 160, 68, 134, 229, 189, 61, 213, 164, 45, 126, 190, 176, 255, 249, 130, 129, 193, 118, 17, 247, 79, 231, 17, 74, 20, 165, 83, 4, 152, 62, 35, 4, 201, 1, 246, 174, 49, 91, 22, 197, 230, 192, 217, 249, 72, 255, 151, 254, 111, 141, 131, 39 }, new byte[] { 29, 146, 241, 142, 24, 66, 78, 128, 17, 36, 21, 53, 98, 187, 199, 80, 220, 243, 125, 165, 99, 245, 33, 85 }, null, "User", "user1" },
                    { "e0db10b0-d24c-44e6-86e6-686dcfd9eca2", "publisher1@gmail.com", false, new byte[] { 114, 127, 53, 204, 32, 234, 113, 66, 135, 87, 56, 200, 119, 178, 242, 229, 217, 233, 162, 211, 106, 137, 130, 180, 64, 229, 255, 243, 198, 211, 54, 66, 36, 100, 125, 5, 19, 193, 160, 73, 238, 33, 3, 253, 182, 56, 134, 138, 55, 5, 240, 100, 222, 61, 151, 7, 138, 72, 149, 90, 202, 154, 234, 167 }, new byte[] { 162, 3, 236, 244, 193, 113, 121, 43, 86, 83, 70, 232, 160, 205, 83, 200, 15, 143, 133, 136, 127, 241, 76, 17 }, "DeepSilver", "Publisher", "publisher1" },
                    { "dd9d8aa6-a443-43f6-b840-e09c9f64c185", "admin@gmail.com", false, new byte[] { 125, 219, 75, 82, 52, 179, 6, 29, 204, 48, 110, 223, 40, 210, 224, 139, 133, 82, 189, 186, 208, 149, 20, 250, 198, 233, 167, 121, 251, 145, 222, 61, 36, 233, 75, 12, 77, 36, 32, 7, 210, 238, 85, 218, 37, 165, 222, 151, 92, 223, 202, 223, 162, 170, 37, 39, 222, 62, 119, 30, 162, 199, 227, 197 }, new byte[] { 212, 62, 204, 165, 25, 114, 157, 187, 51, 81, 78, 180, 128, 214, 8, 5, 242, 98, 35, 5, 13, 76, 129, 96 }, null, "Admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1437c530-183c-44ec-88aa-05481dfd38e1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5343b58b-a88e-4e6c-b191-8c3c3cf85c82");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b98f612b-cef3-4978-bed6-2930cff0d367");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "dd9d8aa6-a443-43f6-b840-e09c9f64c185");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e0db10b0-d24c-44e6-86e6-686dcfd9eca2");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsInvalidated = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 215, DateTimeKind.Utc).AddTicks(9297), new DateTime(2022, 5, 4, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1309), new DateTime(2022, 6, 23, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1468), new DateTime(2021, 7, 8, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1473), new DateTime(2022, 8, 5, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1476), new DateTime(2022, 7, 13, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1510), new DateTime(2022, 6, 13, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1515), new DateTime(2022, 6, 23, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1516) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1518), new DateTime(2022, 7, 28, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1519) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1521), new DateTime(2022, 6, 23, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1525), new DateTime(2022, 7, 13, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1528), new DateTime(2022, 7, 23, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1529) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 12, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1531), new DateTime(2022, 6, 13, 18, 48, 9, 216, DateTimeKind.Utc).AddTicks(1532) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "0d65ef75-a268-45bb-9f3f-5e551be85669", "moderator@gmail.com", false, new byte[] { 87, 170, 85, 111, 233, 49, 236, 16, 229, 219, 44, 32, 123, 221, 186, 110, 39, 56, 61, 193, 26, 144, 157, 35, 96, 58, 23, 218, 45, 168, 2, 214, 54, 162, 17, 246, 193, 154, 108, 97, 17, 241, 123, 119, 77, 226, 149, 51, 75, 167, 253, 179, 16, 166, 66, 190, 113, 90, 65, 17, 46, 118, 159, 206 }, new byte[] { 142, 106, 199, 24, 219, 167, 157, 132, 152, 69, 9, 248, 170, 186, 221, 72, 162, 86, 166, 8, 190, 246, 240, 205 }, null, "Moderator", "moderator1" },
                    { "8364e9b9-1ed4-403c-bc8a-f37b53c31454", "manager1@gmail.com", false, new byte[] { 45, 156, 193, 21, 61, 214, 255, 74, 11, 7, 32, 53, 152, 108, 156, 159, 189, 84, 207, 45, 242, 255, 57, 253, 73, 154, 163, 48, 139, 30, 43, 90, 128, 245, 144, 157, 177, 29, 103, 16, 251, 50, 31, 55, 177, 225, 227, 45, 45, 172, 219, 14, 112, 0, 22, 109, 190, 178, 183, 155, 253, 133, 142, 209 }, new byte[] { 79, 191, 222, 166, 32, 135, 185, 244, 223, 226, 160, 228, 171, 26, 221, 27, 55, 165, 172, 238, 146, 4, 49, 108 }, null, "Manager", "manager1" },
                    { "08e61602-3a78-4676-bd53-b1269acf7de4", "user1@gmail.com", false, new byte[] { 178, 71, 218, 14, 19, 236, 213, 12, 190, 52, 127, 229, 170, 172, 254, 202, 234, 253, 120, 221, 91, 237, 225, 137, 125, 224, 43, 33, 22, 26, 119, 158, 74, 213, 202, 201, 231, 53, 226, 111, 5, 207, 178, 176, 43, 100, 221, 221, 79, 11, 7, 4, 197, 34, 75, 132, 209, 33, 98, 190, 17, 179, 74, 217 }, new byte[] { 11, 214, 89, 184, 244, 75, 91, 147, 203, 236, 89, 213, 178, 54, 235, 198, 200, 250, 32, 163, 70, 72, 172, 127 }, null, "User", "user1" },
                    { "db098567-071c-49d5-b569-093a809ab699", "publisher1@gmail.com", false, new byte[] { 247, 164, 142, 208, 198, 188, 196, 40, 251, 219, 107, 237, 168, 247, 143, 45, 184, 54, 39, 148, 254, 81, 19, 70, 101, 207, 240, 111, 106, 143, 199, 138, 80, 211, 235, 172, 83, 85, 50, 172, 147, 48, 234, 25, 123, 140, 212, 68, 126, 102, 34, 217, 213, 129, 43, 194, 169, 247, 111, 34, 13, 162, 64, 122 }, new byte[] { 218, 113, 190, 45, 99, 18, 130, 234, 190, 56, 59, 11, 201, 232, 117, 75, 61, 123, 167, 73, 149, 163, 223, 119 }, "DeepSilver", "Publisher", "publisher1" },
                    { "1ad744c5-ab8b-4f48-a4b3-9fa839e97f9b", "admin@gmail.com", false, new byte[] { 27, 159, 69, 183, 228, 253, 230, 148, 135, 69, 60, 193, 171, 138, 2, 160, 249, 100, 218, 214, 130, 232, 204, 95, 216, 232, 248, 107, 184, 110, 96, 136, 245, 239, 44, 159, 229, 63, 12, 205, 108, 252, 103, 134, 66, 180, 15, 87, 42, 111, 22, 112, 172, 77, 231, 57, 77, 188, 10, 165, 225, 190, 229, 223 }, new byte[] { 24, 244, 58, 179, 47, 123, 76, 193, 23, 6, 230, 244, 23, 227, 76, 58, 40, 226, 50, 87, 42, 188, 188, 43 }, null, "Admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }
    }
}
