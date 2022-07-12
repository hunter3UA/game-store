using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class CreateTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.Sql(@"create trigger 
                                    Games_Update on Games AFTER UPDATE AS 
                                    Declare @OldGameKey nvarchar(500)
		                            Declare @NewGameKey nvarchar(500)
                                    Declare @IsDeleted bit
		                            select @OldGameKey= ""Key"" from deleted
                                    select @NewGameKey = ""Key"" from inserted
                                    select @IsDeleted = IsDeleted from inserted
                                    if @OldGameKey != @NewGameKey
                                    Update OrderDetails
                                    Set GameKey = @NewGameKey
                                    Where GameKey = @OldGameKey
                                    if @IsDeleted = 1
                                    Update OrderDetails

                                    Set IsDeleted = 1

                                    Where GameKey = @NewGameKey And OrderId in (Select Id From Orders Where ""Status"" = 0 Or ""Status"" = 3)
                            
                    ");
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 392, DateTimeKind.Utc).AddTicks(8303), new DateTime(2022, 4, 3, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(292) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(738), new DateTime(2022, 5, 23, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(851), new DateTime(2021, 6, 7, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(857), new DateTime(2022, 7, 5, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(861), new DateTime(2022, 6, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(865), new DateTime(2022, 5, 13, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(868), new DateTime(2022, 5, 23, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(871), new DateTime(2022, 6, 27, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(873) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(874), new DateTime(2022, 5, 23, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(877), new DateTime(2022, 6, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(881), new DateTime(2022, 6, 22, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 12, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(884), new DateTime(2022, 5, 13, 11, 26, 22, 393, DateTimeKind.Utc).AddTicks(886) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop trigger Publishers_Update");
            migrationBuilder.Sql("drop trigger Games_Update");
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(3475), new DateTime(2022, 4, 2, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5033), new DateTime(2022, 5, 22, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5101), new DateTime(2021, 6, 6, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5105), new DateTime(2022, 7, 4, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5106) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5107), new DateTime(2022, 6, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5109) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5110), new DateTime(2022, 5, 12, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5112), new DateTime(2022, 5, 22, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5114), new DateTime(2022, 6, 26, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5115) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5116), new DateTime(2022, 5, 22, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5118), new DateTime(2022, 6, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5120), new DateTime(2022, 6, 21, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5121) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 11, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5122), new DateTime(2022, 5, 12, 16, 46, 14, 918, DateTimeKind.Utc).AddTicks(5124) });
        }
    }
}
