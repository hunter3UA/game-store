using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class CreatePublisherUpdateTrigger : Migration
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
		                           Where PublisherName=@OldPublisherName
								   Update Users
								   Set PublisherName=@NewPublisherName
								   Where PublisherName=@OldPublisherName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop trigger Publishers_Update");
        }
    }
}
