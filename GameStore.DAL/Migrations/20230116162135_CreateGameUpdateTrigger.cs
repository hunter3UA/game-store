using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class CreateGameUpdateTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                                    Where GameKey = @NewGameKey And OrderId in (Select Id From Orders Where ""Status"" = 0 Or ""Status"" = 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop trigger Games_Update");
        }
    }
}
