using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "PublisherTranslates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "PlatformTypeTranslates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "GenreTranslates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "GameTranslates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 438, DateTimeKind.Utc).AddTicks(9964), new DateTime(2022, 5, 19, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2433), new DateTime(2022, 7, 8, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2578) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2588), new DateTime(2021, 7, 23, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2593), new DateTime(2022, 8, 20, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2594) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2596), new DateTime(2022, 7, 28, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2597) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2600), new DateTime(2022, 6, 28, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2603), new DateTime(2022, 7, 8, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2604) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2606), new DateTime(2022, 8, 12, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2607) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2610), new DateTime(2022, 7, 8, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2612) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2614), new DateTime(2022, 7, 28, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2615) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2617), new DateTime(2022, 8, 7, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2618) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 27, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2620), new DateTime(2022, 6, 28, 12, 55, 51, 439, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "c73e3451-c0b8-4b64-90e0-98882971d9bf", "moderator@gmail.com", false, new byte[] { 247, 174, 164, 237, 8, 154, 34, 158, 125, 25, 103, 101, 244, 252, 140, 199, 198, 62, 254, 203, 128, 212, 239, 20, 28, 196, 161, 131, 253, 59, 131, 176, 10, 136, 131, 37, 162, 156, 47, 101, 175, 199, 206, 162, 191, 104, 252, 127, 98, 144, 120, 164, 250, 26, 111, 235, 151, 233, 30, 18, 36, 111, 136, 153 }, new byte[] { 197, 233, 171, 99, 42, 46, 124, 63, 126, 204, 53, 32, 201, 68, 49, 219, 157, 213, 87, 59, 114, 5, 232, 177 }, null, "Moderator", "moderator1" },
                    { "9ac9bede-9072-4798-ba23-1dc6d2ef23b2", "manager1@gmail.com", false, new byte[] { 241, 19, 39, 66, 12, 253, 194, 230, 182, 59, 37, 6, 227, 71, 64, 162, 47, 33, 27, 41, 232, 228, 44, 169, 54, 8, 53, 102, 229, 234, 123, 239, 197, 175, 128, 156, 13, 99, 46, 41, 50, 83, 252, 56, 72, 145, 125, 133, 66, 173, 62, 247, 21, 112, 86, 11, 114, 72, 239, 74, 6, 71, 186, 211 }, new byte[] { 13, 165, 181, 1, 43, 165, 177, 163, 10, 6, 32, 206, 175, 93, 200, 101, 208, 57, 247, 157, 215, 47, 213, 143 }, null, "Manager", "manager1" },
                    { "617a717c-4e4b-464f-ba51-a355a305b172", "user1@gmail.com", false, new byte[] { 220, 253, 58, 21, 155, 31, 27, 101, 15, 192, 26, 239, 115, 247, 75, 90, 110, 78, 227, 200, 153, 239, 72, 101, 4, 253, 164, 63, 135, 1, 184, 231, 57, 124, 207, 71, 133, 251, 68, 208, 147, 18, 60, 103, 153, 133, 154, 206, 246, 175, 23, 54, 235, 232, 76, 232, 12, 110, 95, 215, 214, 226, 205, 13 }, new byte[] { 115, 45, 201, 80, 22, 24, 13, 151, 134, 103, 40, 62, 189, 175, 72, 215, 170, 88, 245, 73, 101, 255, 189, 234 }, null, "User", "user1" },
                    { "3f8e3979-706e-4064-b987-65b8c83166eb", "publisher1@gmail.com", false, new byte[] { 54, 176, 234, 71, 198, 159, 241, 16, 222, 219, 31, 63, 223, 126, 23, 250, 171, 14, 135, 242, 120, 114, 26, 214, 73, 240, 67, 224, 220, 218, 204, 227, 47, 213, 73, 6, 151, 61, 24, 24, 57, 31, 183, 97, 203, 62, 135, 134, 53, 190, 58, 168, 95, 152, 161, 202, 139, 220, 175, 116, 91, 50, 24, 5 }, new byte[] { 85, 250, 12, 199, 166, 34, 144, 41, 223, 196, 7, 163, 129, 93, 245, 124, 221, 24, 21, 246, 253, 246, 199, 127 }, "DeepSilver", "Publisher", "publisher1" },
                    { "a207038d-70ee-496b-abe7-c7dc262b94dd", "admin@gmail.com", false, new byte[] { 226, 96, 107, 61, 75, 119, 30, 68, 74, 180, 221, 44, 160, 39, 72, 207, 208, 110, 138, 119, 134, 173, 21, 249, 144, 62, 77, 250, 29, 160, 122, 132, 118, 133, 170, 246, 8, 48, 132, 44, 200, 21, 40, 31, 76, 51, 128, 78, 72, 180, 186, 218, 245, 249, 74, 37, 140, 142, 188, 199, 58, 119, 16, 217 }, new byte[] { 168, 101, 183, 51, 97, 8, 53, 253, 18, 215, 200, 98, 7, 93, 161, 33, 129, 54, 195, 67, 60, 93, 176, 9 }, null, "Admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3f8e3979-706e-4064-b987-65b8c83166eb");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "617a717c-4e4b-464f-ba51-a355a305b172");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9ac9bede-9072-4798-ba23-1dc6d2ef23b2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a207038d-70ee-496b-abe7-c7dc262b94dd");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c73e3451-c0b8-4b64-90e0-98882971d9bf");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "PublisherTranslates");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "PlatformTypeTranslates");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "GenreTranslates");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "GameTranslates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
