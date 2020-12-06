using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
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
                    CreatedUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
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

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    HomeTeamId = table.Column<int>(nullable: false),
                    PlayerHomeTeamId = table.Column<int>(nullable: false),
                    GoalsHomeTeam = table.Column<int>(nullable: false),
                    ResultKindHomeTeam = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    PlayerAwayTeamId = table.Column<int>(nullable: false),
                    GoalsAwayTeam = table.Column<int>(nullable: false),
                    ResultKindAwayTeam = table.Column<int>(nullable: false),
                    GameType = table.Column<int>(nullable: false),
                    GameDateUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Histories_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Histories_Players_PlayerAwayTeamId",
                        column: x => x.PlayerAwayTeamId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Histories_Players_PlayerHomeTeamId",
                        column: x => x.PlayerHomeTeamId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { 1, new DateTime(2020, 12, 6, 14, 48, 21, 953, DateTimeKind.Utc).AddTicks(3833), "BOSTON_BRUINS", new DateTime(2020, 12, 6, 14, 48, 21, 955, DateTimeKind.Utc).AddTicks(732), "Boston" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { 2, new DateTime(2020, 12, 6, 14, 48, 21, 955, DateTimeKind.Utc).AddTicks(1884), "BUFFALO_SABRES", new DateTime(2020, 12, 6, 14, 48, 21, 955, DateTimeKind.Utc).AddTicks(1903), "Buffalo" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { 3, new DateTime(2020, 12, 6, 14, 48, 21, 955, DateTimeKind.Utc).AddTicks(1920), "PHILADELPHIA_FLYERS", new DateTime(2020, 12, 6, 14, 48, 21, 955, DateTimeKind.Utc).AddTicks(1922), "Philadelpia" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedUTC", "FirstName", "LastName", "ModifiedUTC", "Nickname", "SelectedTeamId" },
                values: new object[] { 2, new DateTime(2020, 12, 6, 14, 48, 21, 959, DateTimeKind.Utc).AddTicks(2520), "Player", "2", new DateTime(2020, 12, 6, 14, 48, 21, 959, DateTimeKind.Utc).AddTicks(2522), "Player2", 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedUTC", "FirstName", "LastName", "ModifiedUTC", "Nickname", "SelectedTeamId" },
                values: new object[] { 1, new DateTime(2020, 12, 6, 14, 48, 21, 959, DateTimeKind.Utc).AddTicks(2164), "Player", "1", new DateTime(2020, 12, 6, 14, 48, 21, 959, DateTimeKind.Utc).AddTicks(2169), "Player1", 2 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedUTC", "FirstName", "LastName", "ModifiedUTC", "Nickname", "SelectedTeamId" },
                values: new object[] { 3, new DateTime(2020, 12, 6, 14, 48, 21, 959, DateTimeKind.Utc).AddTicks(2530), "Player", "3", new DateTime(2020, 12, 6, 14, 48, 21, 959, DateTimeKind.Utc).AddTicks(2530), "Player3", 3 });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
