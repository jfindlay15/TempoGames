using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingForeignkeyfromPlayerResultstoGameResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Game_GameId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_GameId",
                table: "GameResults");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GameResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_GameId",
                table: "GameResults",
                column: "GameId",
                unique: true,
                filter: "[GameId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Game_GameId",
                table: "GameResults",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Game_GameId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_GameId",
                table: "GameResults");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GameResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_GameId",
                table: "GameResults",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Game_GameId",
                table: "GameResults",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
