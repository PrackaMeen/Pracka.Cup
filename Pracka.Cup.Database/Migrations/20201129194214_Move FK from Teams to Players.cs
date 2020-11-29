using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class MoveFKfromTeamstoPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_PlayerModelId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PlayerModelId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PlayerModelId",
                table: "Teams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerModelId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerModelId",
                table: "Teams",
                column: "PlayerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Players_PlayerModelId",
                table: "Teams",
                column: "PlayerModelId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
