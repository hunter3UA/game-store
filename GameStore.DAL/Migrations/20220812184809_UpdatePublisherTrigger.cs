using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdatePublisherTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop trigger Publishers_Update");
            migrationBuilder.Sql(@"create trigger 
                                   Publishers_Update on Publishers AFTER UPDATE AS 
		                           Declare @IsDeleted bit
		                           Declare @NewPublisherName nvarchar(150)
                                   Declare @OldPublisherName nvarchar(150)
                                   select @NewPublisherName=CompanyName from inserted
                                   select @OldPublisherName=CompanyName from deleted  
                                   select @IsDeleted=IsDeleted from inserted
		                           if  
                                   @IsDeleted=1 And @NewPublisherName=@OldPublisherName
		                           Update Games
		                           Set PublisherName=null
		                           Where PublisherName= @OldPublisherName
		                           else if
                                   @NewPublisherName!=@OldPublisherName And @IsDeleted=0
		                           Update Games
		                           Set PublisherName=@NewPublisherName
		                           Where PublisherName=@OldPublisherName
								   Update Users
								   Set PublisherName=@NewPublisherName
								   Where PublisherName=@OldPublisherName");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create trigger 
                                   Publishers_Update on Publishers AFTER UPDATE AS 
		                           Declare @IsDeleted bit
		                           Declare @NewPublisherName nvarchar(150)
                                   Declare @OldPublisherName nvarchar(150)
                                   select @NewPublisherName=CompanyName from inserted
                                   select @OldPublisherName=CompanyName from deleted  
                                   select @IsDeleted=IsDeleted from inserted
		                           if  
                                   @IsDeleted=1 And @NewPublisherName=@OldPublisherName
		                           Update Games
		                           Set PublisherName=null
		                           Where PublisherName= @OldPublisherName
		                           else if
                                   @NewPublisherName!=@OldPublisherName And @IsDeleted=0
		                           Update Games
		                           Set PublisherName=@NewPublisherName
		                           Where PublisherName=@OldPublisherName");
            migrationBuilder.Sql("drop trigger Publishers_Update");

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
    }
}
