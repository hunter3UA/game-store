using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class RemoveReletionsWithPublisherGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PublisherId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(2927), new DateTime(2022, 3, 27, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4475), "GSC" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4801), new DateTime(2022, 5, 16, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4853), "DeepSiler" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4906), new DateTime(2021, 5, 31, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4909), "GSC" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4910), new DateTime(2022, 6, 28, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4912), "Activision" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4913), new DateTime(2022, 6, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4914), "Firaxis" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4915), new DateTime(2022, 5, 6, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4917), "Bohemia Interactive" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4917), new DateTime(2022, 5, 16, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4919), "GSC" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4920), new DateTime(2022, 6, 20, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4921), "Activision" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4935), new DateTime(2022, 5, 16, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4937), "GSC" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4937), new DateTime(2022, 6, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4939), "Firaxis" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4940), new DateTime(2022, 6, 15, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4941), "DeepSiler" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 5, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4942), new DateTime(2022, 5, 6, 14, 17, 5, 213, DateTimeKind.Utc).AddTicks(4943), "Activision" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(865), new DateTime(2022, 3, 26, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(1911), 2, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2198), new DateTime(2022, 5, 15, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2268), 1, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2286), new DateTime(2021, 5, 30, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2288), 2, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2289), new DateTime(2022, 6, 27, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2290), 3, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2293), new DateTime(2022, 6, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2295), 4, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2295), new DateTime(2022, 5, 5, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2296), 5, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2297), new DateTime(2022, 5, 15, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2298), 2, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2299), new DateTime(2022, 6, 19, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2301), 3, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2301), new DateTime(2022, 5, 15, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2302), 2, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2303), new DateTime(2022, 6, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2305), 4, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2305), new DateTime(2022, 6, 14, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2306), 1, null });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "PublishedAt", "PublisherId", "PublisherName" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2307), new DateTime(2022, 5, 5, 9, 10, 53, 112, DateTimeKind.Utc).AddTicks(2308), 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
