using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class AddUserAndRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsInvalidated = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(3514), new DateTime(2022, 4, 19, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6615), new DateTime(2022, 6, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6737), new DateTime(2021, 6, 23, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6744), new DateTime(2022, 7, 21, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6749), new DateTime(2022, 6, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6754), new DateTime(2022, 5, 29, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6756) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6759), new DateTime(2022, 6, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6764), new DateTime(2022, 7, 13, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6862), new DateTime(2022, 6, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6868), new DateTime(2022, 6, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6873), new DateTime(2022, 7, 8, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 28, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6878), new DateTime(2022, 5, 29, 14, 47, 11, 938, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_UserId",
                table: "Publishers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Users_UserId",
                table: "Publishers");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_UserId",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Publishers");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(2731), new DateTime(2022, 4, 7, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4229), new DateTime(2022, 5, 27, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4294), new DateTime(2021, 6, 11, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4297), new DateTime(2022, 7, 9, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4299) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4300), new DateTime(2022, 6, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4303), new DateTime(2022, 5, 17, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4306), new DateTime(2022, 5, 27, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4309), new DateTime(2022, 7, 1, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4311), new DateTime(2022, 5, 27, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4315), new DateTime(2022, 6, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4316) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4318), new DateTime(2022, 6, 26, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4319) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 16, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4320), new DateTime(2022, 5, 17, 13, 13, 23, 222, DateTimeKind.Utc).AddTicks(4321) });
        }
    }
}
