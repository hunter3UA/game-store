using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class UpdateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentId1",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("1e6e6b1a-386d-418b-a1e0-1476edb3592a"));

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("63b451fc-ec0c-4900-ab63-6c2148895da0"));

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("789b89f2-b170-4b40-8e86-d08c8fa09923"));

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("e61d0043-d8a5-4f67-9c9d-188fef333cd4"));

            migrationBuilder.DropColumn(
                name: "CommentId1",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("b5fa0d51-b004-47c8-804d-5f17e6b16c20"), "Mobile" },
                    { new Guid("06ce1027-b648-4000-a314-0b9efa0147ab"), "Browser" },
                    { new Guid("50f1f4f3-9c86-4b35-8187-b87721505a94"), "Desktop" },
                    { new Guid("58c7ec73-7279-450c-bef7-9feca0e6e67d"), "Console" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_ParentId",
                table: "Comments",
                column: "fk_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_fk_ParentId",
                table: "Comments",
                column: "fk_ParentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_fk_ParentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_fk_ParentId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("06ce1027-b648-4000-a314-0b9efa0147ab"));

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("50f1f4f3-9c86-4b35-8187-b87721505a94"));

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("58c7ec73-7279-450c-bef7-9feca0e6e67d"));

            migrationBuilder.DeleteData(
                table: "PlatformTypes",
                keyColumn: "PlatformTypeId",
                keyValue: new Guid("b5fa0d51-b004-47c8-804d-5f17e6b16c20"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId1",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("63b451fc-ec0c-4900-ab63-6c2148895da0"), "Mobile" },
                    { new Guid("e61d0043-d8a5-4f67-9c9d-188fef333cd4"), "Browser" },
                    { new Guid("789b89f2-b170-4b40-8e86-d08c8fa09923"), "Desktop" },
                    { new Guid("1e6e6b1a-386d-418b-a1e0-1476edb3592a"), "Console" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId1",
                table: "Comments",
                column: "CommentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId1",
                table: "Comments",
                column: "CommentId1",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
