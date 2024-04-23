using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removingGameResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_GameResults_GameResultsId",
                table: "PlayerResults");

            migrationBuilder.DropTable(
                name: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_PlayerResults_GameResultsId",
                table: "PlayerResults");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "PlayerResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WonGame",
                table: "PlayerResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResults_GameId",
                table: "PlayerResults",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_Game_GameId",
                table: "PlayerResults",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResults_Game_GameId",
                table: "PlayerResults");

            migrationBuilder.DropIndex(
                name: "IX_PlayerResults_GameId",
                table: "PlayerResults");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "PlayerResults");

            migrationBuilder.DropColumn(
                name: "WonGame",
                table: "PlayerResults");

            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    WinnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameResults_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameResults_Player_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResults_GameResultsId",
                table: "PlayerResults",
                column: "GameResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_GameId",
                table: "GameResults",
                column: "GameId",
                unique: true,
                filter: "[GameId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_WinnerId",
                table: "GameResults",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResults_GameResults_GameResultsId",
                table: "PlayerResults",
                column: "GameResultsId",
                principalTable: "GameResults",
                principalColumn: "Id");
        }
    }
}
