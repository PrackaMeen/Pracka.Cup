namespace Pracka.Cup.Database.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Pracka.Cup.Database.DatabaseFunctions;
    using Pracka.Cup.Database.Enums;
    using Pracka.Cup.Database.Helpers;

    public partial class ScoreBoardSplit : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCustomFunction<GetGamesStatisticsFunction>();
            migrationBuilder.AddCustomFunction<GetLoss1ptStatisticsFunction>();
            migrationBuilder.AddCustomFunction<GetWins2ptsStatisticsFunction>();
            migrationBuilder.AddCustomFunction<GetWins3ptsStatisticsFunction>();
            migrationBuilder.AddCustomFunction<GetCompleteStatisticsFunction>();
            migrationBuilder.AddCustomFunction<GetScoreBoardStatisticsFunction>();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCustomFunction<GetGamesStatisticsFunction>();
            migrationBuilder.DropCustomFunction<GetLoss1ptStatisticsFunction>();
            migrationBuilder.DropCustomFunction<GetWins2ptsStatisticsFunction>();
            migrationBuilder.DropCustomFunction<GetWins3ptsStatisticsFunction>();
            migrationBuilder.DropCustomFunction<GetCompleteStatisticsFunction>();
            migrationBuilder.DropCustomFunction<GetScoreBoardStatisticsFunction>();
        }
    }
}
