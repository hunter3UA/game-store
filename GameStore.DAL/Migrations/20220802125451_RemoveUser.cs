using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Users_UserId",
                table: "Publishers");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_UserId",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Publishers");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(3962), new DateTime(2022, 4, 24, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(5721) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(5981), new DateTime(2022, 6, 13, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6055) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6065), new DateTime(2021, 6, 28, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6068) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6070), new DateTime(2022, 7, 26, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6074), new DateTime(2022, 7, 3, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6077), new DateTime(2022, 6, 3, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6081), new DateTime(2022, 6, 13, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6084), new DateTime(2022, 7, 18, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6087), new DateTime(2022, 6, 13, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6090), new DateTime(2022, 7, 3, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6093), new DateTime(2022, 7, 13, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6095) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 2, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6097), new DateTime(2022, 6, 3, 12, 54, 50, 544, DateTimeKind.Utc).AddTicks(6098) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Publishers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(5221), new DateTime(2022, 4, 23, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8260), new DateTime(2022, 6, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8378), new DateTime(2021, 6, 27, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8386), new DateTime(2022, 7, 25, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8391), new DateTime(2022, 7, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8396), new DateTime(2022, 6, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8401), new DateTime(2022, 6, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8449) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8452), new DateTime(2022, 7, 17, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8455) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8458), new DateTime(2022, 6, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8462), new DateTime(2022, 7, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8465) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8468), new DateTime(2022, 7, 12, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 8, 1, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8474), new DateTime(2022, 6, 2, 12, 39, 14, 628, DateTimeKind.Utc).AddTicks(8476) });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_UserId",
                table: "Publishers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Users_UserId",
                table: "Publishers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
