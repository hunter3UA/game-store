using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveGameNameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_Name",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "GameId", "IsDeleted", "IsQuote", "Name", "ParentCommentId" },
                values: new object[] { 1, "This is my favourite game", 1, false, false, "Oleksandr", null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(5172), new DateTime(2022, 4, 6, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(6962) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7046), new DateTime(2022, 5, 26, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7139), new DateTime(2021, 6, 10, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7145), new DateTime(2022, 7, 8, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7149), new DateTime(2022, 6, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7153), new DateTime(2022, 5, 16, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7156), new DateTime(2022, 5, 26, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7158) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7160), new DateTime(2022, 6, 30, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7164), new DateTime(2022, 5, 26, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7167), new DateTime(2022, 6, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7171), new DateTime(2022, 6, 25, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7175), new DateTime(2022, 5, 16, 10, 27, 12, 235, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "GameId", "IsDeleted", "IsQuote", "Name", "ParentCommentId" },
                values: new object[] { 2, "And my too", 1, false, false, "Oleg", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);
        }
    }
}
