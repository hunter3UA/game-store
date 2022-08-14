using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class ModPublisherData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(6007), new DateTime(2022, 4, 28, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8658), new DateTime(2022, 6, 17, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8808) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8821), new DateTime(2021, 7, 2, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8826), new DateTime(2022, 7, 30, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8831), new DateTime(2022, 7, 7, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8834), new DateTime(2022, 6, 7, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8836) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8838), new DateTime(2022, 6, 17, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8839) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8842), new DateTime(2022, 7, 22, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8845), new DateTime(2022, 6, 17, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8849), new DateTime(2022, 7, 7, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8852), new DateTime(2022, 7, 17, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8854) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8856), new DateTime(2022, 6, 7, 11, 11, 36, 684, DateTimeKind.Utc).AddTicks(8858) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyName",
                value: "DeepSilver");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "PasswordHash", "PasswordSalt", "PublisherName", "Role", "UserName" },
                values: new object[,]
                {
                    { "3c3fb61d-39ad-4f7e-a47f-b95a50ac1506", "moderator@gmail.com", false, new byte[] { 10, 80, 47, 90, 117, 187, 30, 1, 129, 205, 32, 83, 131, 131, 116, 194, 125, 232, 107, 207, 234, 86, 152, 138, 7, 241, 236, 220, 171, 136, 193, 118, 183, 135, 134, 73, 176, 155, 85, 136, 232, 25, 201, 164, 152, 45, 247, 125, 211, 92, 5, 208, 254, 68, 171, 165, 195, 165, 138, 163, 159, 12, 129, 103 }, new byte[] { 249, 95, 156, 79, 148, 207, 179, 118, 255, 46, 255, 30, 157, 242, 55, 23, 131, 249, 64, 75, 200, 157, 71, 90 }, null, "Moderator", "moderator1" },
                    { "dcc11b2a-ee95-4d9d-bae5-03110eb03fd6", "manager1@gmail.com", false, new byte[] { 141, 77, 118, 225, 179, 77, 143, 231, 255, 2, 125, 35, 213, 141, 75, 247, 245, 165, 185, 217, 120, 42, 85, 42, 230, 25, 244, 59, 174, 101, 145, 4, 225, 73, 197, 119, 52, 147, 223, 185, 191, 14, 220, 32, 116, 245, 161, 197, 117, 15, 10, 161, 170, 179, 218, 235, 42, 23, 216, 43, 247, 224, 186, 49 }, new byte[] { 155, 60, 205, 55, 124, 12, 229, 1, 134, 200, 51, 23, 168, 241, 8, 144, 192, 64, 232, 74, 8, 150, 19, 8 }, null, "Manager", "manager1" },
                    { "d08d6d7d-9bea-42c7-b544-217b61881a6e", "user1@gmail.com", false, new byte[] { 67, 174, 187, 178, 126, 206, 251, 69, 26, 135, 126, 209, 31, 233, 139, 15, 237, 135, 20, 239, 27, 47, 200, 112, 229, 108, 10, 169, 215, 56, 196, 45, 150, 254, 119, 2, 238, 96, 156, 234, 177, 22, 177, 227, 111, 59, 47, 8, 170, 11, 39, 230, 252, 216, 6, 23, 255, 129, 116, 215, 225, 226, 227, 166 }, new byte[] { 136, 149, 229, 204, 241, 175, 174, 40, 117, 125, 177, 56, 59, 18, 156, 155, 29, 135, 188, 224, 10, 102, 17, 161 }, null, "User", "user1" },
                    { "f050d9d4-c7cd-47ab-a609-084f177ca40d", "publisher1@gmail.com", false, new byte[] { 130, 243, 150, 8, 223, 247, 223, 210, 46, 87, 58, 56, 78, 235, 22, 126, 98, 0, 26, 169, 120, 44, 89, 23, 63, 192, 56, 194, 40, 252, 150, 13, 189, 247, 110, 56, 252, 1, 22, 90, 87, 52, 127, 141, 58, 72, 92, 207, 91, 210, 85, 185, 195, 207, 234, 155, 48, 116, 193, 76, 54, 100, 222, 233 }, new byte[] { 237, 237, 219, 203, 93, 249, 43, 70, 233, 175, 42, 68, 87, 186, 79, 71, 140, 162, 21, 100, 124, 190, 37, 87 }, "DeepSilver", "Publisher", "publisher1" },
                    { "cf450b40-8965-4329-a569-b59982929b78", "admin@gmail.com", false, new byte[] { 7, 225, 124, 251, 163, 14, 49, 91, 163, 161, 230, 33, 76, 175, 239, 191, 150, 154, 238, 51, 105, 46, 154, 161, 77, 207, 212, 83, 167, 111, 101, 91, 144, 109, 153, 22, 33, 152, 68, 31, 195, 124, 1, 193, 109, 103, 10, 3, 91, 64, 244, 178, 218, 212, 44, 204, 219, 35, 117, 183, 96, 106, 74, 123 }, new byte[] { 121, 216, 236, 2, 199, 202, 106, 26, 150, 245, 253, 150, 234, 69, 56, 39, 237, 87, 207, 113, 26, 145, 120, 152 }, null, "Admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3c3fb61d-39ad-4f7e-a47f-b95a50ac1506");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cf450b40-8965-4329-a569-b59982929b78");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d08d6d7d-9bea-42c7-b544-217b61881a6e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "dcc11b2a-ee95-4d9d-bae5-03110eb03fd6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f050d9d4-c7cd-47ab-a609-084f177ca40d");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(5940), new DateTime(2022, 4, 28, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8060), new DateTime(2022, 6, 17, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8203) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8214), new DateTime(2021, 7, 2, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8216) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8219), new DateTime(2022, 7, 30, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8222), new DateTime(2022, 7, 7, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8223) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8225), new DateTime(2022, 6, 7, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8227) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8229), new DateTime(2022, 6, 17, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8232), new DateTime(2022, 7, 22, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8236), new DateTime(2022, 6, 17, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8238) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8240), new DateTime(2022, 7, 7, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8243), new DateTime(2022, 7, 17, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 6, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8246), new DateTime(2022, 6, 7, 7, 15, 42, 870, DateTimeKind.Utc).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyName",
                value: "DeepSiler");
        }
    }
}
