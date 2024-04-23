using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingGameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlayerResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "PlayerResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Headshots",
                table: "PlayerResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResults_GameId",
                table: "PlayerResults",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_MapId",
                table: "Games",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_Games_GameId",
                table: "PlayerResults",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_Games_GameId",
                table: "PlayerResults");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_PlayerResults_GameId",
                table: "PlayerResults");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "PlayerResults");

            migrationBuilder.DropColumn(
                name: "Headshots",
                table: "PlayerResults");

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The Capital" },
                    { 2, "Arcadia" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Player1" },
                    { 2, 10, "Player2" }
                });

            migrationBuilder.InsertData(
                table: "PlayerResults",
                columns: new[] { "Id", "Deaths", "GameDuration", "KillStreak", "Kills", "PlayerId", "StartTime", "WonGame" },
                values: new object[] { 1, 10, 300, 10, 5, 2, new DateTime(2024, 4, 22, 14, 10, 24, 992, DateTimeKind.Local).AddTicks(6233), true });
        }
    }
}
