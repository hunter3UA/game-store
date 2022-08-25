using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Genres",
                columns: new[] { "Id", "CategoryId", "Description", "IsDeleted", "Name", "ParentGenreId" },
                values: new object[,]
                {
                    { 17, 1, "Soft drinks, coffees, teas, beers, and ales", false, "Beverages", null },
                    { 24, 8, "Seaweed and fish", false, "Seafood", null },
                    { 23, 7, "Dried fruit and bean curd", false, "Produce", null },
                    { 22, 6, "Prepared meats", false, "Meat/Poultry", null },
                    { 21, 5, "Breads, crackers, pasta, and cereal", false, "Grains/Cereals", null },
                    { 20, 4, "Cheeses", false, "Dairy Products", null },
                    { 19, 3, "Desserts, candies, and sweet breads", false, "Confections", null },
                    { 18, 2, "Sweet and savory sauces, relishes, spreads, and seasonings", false, "Condiments", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "aa740e0d-9b6f-456c-840b-dda5a5195eae", "manager1@gmail.com", false, new byte[] { 152, 97, 139, 63, 226, 119, 78, 40, 109, 117, 80, 5, 189, 60, 44, 155, 143, 173, 80, 211, 142, 168, 41, 117, 169, 250, 199, 151, 215, 96, 19, 16, 150, 28, 100, 225, 63, 152, 94, 193, 213, 71, 8, 203, 159, 137, 249, 160, 105, 176, 172, 146, 211, 68, 28, 75, 212, 15, 235, 3, 141, 176, 78, 148 }, new byte[] { 98, 33, 93, 14, 216, 77, 166, 151, 198, 81, 156, 181, 58, 150, 10, 254, 128, 121, 152, 242, 24, 31, 183, 227 }, null, "Manager", "manager1" },
                    { "36a985c1-b496-4d9a-8333-aaea40ebc3ef", "user1@gmail.com", false, new byte[] { 0, 193, 67, 80, 65, 9, 40, 156, 101, 48, 151, 19, 129, 198, 122, 245, 227, 180, 40, 45, 158, 200, 113, 112, 171, 161, 211, 38, 214, 236, 63, 34, 7, 109, 93, 170, 160, 142, 56, 242, 43, 227, 49, 249, 84, 250, 76, 199, 95, 57, 224, 126, 176, 124, 172, 66, 206, 238, 95, 152, 179, 247, 142, 57 }, new byte[] { 58, 160, 68, 70, 48, 106, 6, 123, 41, 250, 214, 235, 183, 139, 45, 186, 167, 18, 132, 141, 19, 148, 84, 154 }, null, "User", "user1" },
                    { "8940be39-a642-43cf-8f3e-8233dee7f516", "admin@gmail.com", false, new byte[] { 18, 27, 201, 111, 222, 138, 18, 116, 137, 46, 119, 44, 245, 251, 150, 196, 17, 199, 159, 75, 11, 210, 168, 183, 227, 17, 243, 201, 75, 1, 143, 154, 232, 19, 2, 6, 9, 162, 90, 201, 136, 142, 146, 161, 243, 48, 71, 136, 56, 27, 91, 54, 64, 21, 227, 135, 71, 237, 41, 79, 211, 57, 174, 25 }, new byte[] { 186, 191, 152, 2, 137, 119, 71, 176, 109, 27, 175, 178, 23, 146, 93, 166, 105, 169, 104, 224, 99, 177, 122, 194 }, null, "Admin", "admin" },
                    { "98a461f4-37a4-41bf-bf05-0559c7e9e012", "moderator@gmail.com", false, new byte[] { 10, 241, 88, 1, 28, 22, 83, 9, 93, 101, 179, 20, 209, 130, 43, 182, 235, 191, 8, 128, 11, 199, 245, 164, 135, 202, 5, 210, 157, 219, 4, 16, 164, 84, 9, 155, 67, 41, 171, 158, 252, 2, 121, 165, 226, 147, 229, 212, 138, 132, 244, 124, 27, 70, 35, 166, 20, 3, 44, 127, 245, 141, 241, 161 }, new byte[] { 228, 11, 86, 193, 29, 179, 38, 9, 210, 177, 196, 89, 113, 5, 207, 46, 151, 174, 164, 219, 51, 15, 230, 6 }, null, "Moderator", "moderator1" },
                    { "4892ac46-f076-464d-8abf-c3d17700ce22", "publisher1@gmail.com", false, new byte[] { 203, 152, 135, 38, 46, 31, 88, 224, 186, 119, 173, 13, 227, 208, 246, 246, 133, 48, 163, 223, 184, 147, 144, 190, 4, 207, 79, 43, 15, 205, 55, 40, 125, 90, 154, 224, 181, 108, 122, 47, 163, 32, 210, 130, 175, 0, 84, 23, 135, 43, 150, 16, 8, 74, 36, 0, 186, 60, 192, 4, 169, 211, 253, 61 }, new byte[] { 233, 250, 170, 151, 160, 217, 218, 34, 219, 175, 222, 170, 200, 75, 241, 80, 245, 163, 136, 217, 229, 42, 129, 48 }, "DeepSilver", "Publisher", "publisher1" }
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
    }
}
