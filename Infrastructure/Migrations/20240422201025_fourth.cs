using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_Game_GameId",
                table: "PlayerResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_Players_PlayerId",
                table: "PlayerResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_Weapon_WeaponId",
                table: "PlayerResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rank_RankId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "WeaponType");

            migrationBuilder.DropIndex(
                name: "IX_Players_RankId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_PlayerResults_GameId",
                table: "PlayerResults");

            migrationBuilder.DropIndex(
                name: "IX_PlayerResults_WeaponId",
                table: "PlayerResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "PlayerResults");

            migrationBuilder.DropColumn(
                name: "GameResultsId",
                table: "PlayerResults");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "PlayerResults");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "Maps");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_Players_PlayerId",
                table: "PlayerResults",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_Players_PlayerId",
                table: "PlayerResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

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

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "Map");

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "PlayerResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameResultsId",
                table: "PlayerResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "PlayerResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapon_WeaponType_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "WeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_RankId",
                table: "Players",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResults_GameId",
                table: "PlayerResults",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResults_WeaponId",
                table: "PlayerResults",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_MapId",
                table: "Game",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerId",
                table: "Game",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_WeaponTypeId",
                table: "Weapon",
                column: "WeaponTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_Game_GameId",
                table: "PlayerResults",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_Players_PlayerId",
                table: "PlayerResults",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_Weapon_WeaponId",
                table: "PlayerResults",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rank_RankId",
                table: "Players",
                column: "RankId",
                principalTable: "Rank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
