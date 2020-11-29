using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    PlayerHomeTeamId = table.Column<int>(nullable: false),
                    GoalsHomeTeam = table.Column<int>(nullable: false),
                    ResultKindHomeTeam = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    PlayerAwayTeamId = table.Column<int>(nullable: false),
                    GoalsAwayTeam = table.Column<int>(nullable: false),
                    ResultKindAwayTeam = table.Column<int>(nullable: false),
                    GameDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    PlayerModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    SelectedTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_SelectedTeamId",
                        column: x => x.SelectedTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_AwayTeamId",
                table: "Histories",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_HomeTeamId",
                table: "Histories",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_PlayerAwayTeamId",
                table: "Histories",
                column: "PlayerAwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_PlayerHomeTeamId",
                table: "Histories",
                column: "PlayerHomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SelectedTeamId",
                table: "Players",
                column: "SelectedTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerModelId",
                table: "Teams",
                column: "PlayerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Teams_AwayTeamId",
                table: "Histories",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Teams_HomeTeamId",
                table: "Histories",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Players_PlayerAwayTeamId",
                table: "Histories",
                column: "PlayerAwayTeamId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Players_PlayerHomeTeamId",
                table: "Histories",
                column: "PlayerHomeTeamId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Players_PlayerModelId",
                table: "Teams",
                column: "PlayerModelId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_SelectedTeamId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
