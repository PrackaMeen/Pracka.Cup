using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class PlayerHistoriesView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW [dbo].[PlayerHistoriesView]
                AS
				(
					SELECT
						[HistoryAway].[Id] AS [GameId],
						[HistoryAway].[PlayerAwayTeamId] AS [PlayerId],
						[HistoryAway].[AwayTeamId] AS [TeamId],
						[HistoryAway].[GoalsAwayTeam] AS [GoalsScored],
						[HistoryAway].[GoalsHomeTeam] AS [GoalsRecieved],
						[HistoryAway].[GameType] AS [GameType],
						[HistoryAway].[ResultKindAwayTeam] AS [ResultKindTeam],
						[HistoryAway].[GameDateUTC] AS [GameDateUTC],
						[HistoryAway].[CreatedUTC] AS [CreatedUTC],
						[HistoryAway].[ModifiedUTC] AS [ModifiedUTC]
					FROM[PrackaCup].[dbo].[Histories] AS [HistoryAway]
				) UNION (
					SELECT
						[HistoryHome].[Id] AS [GameId],
						[HistoryHome].[PlayerHomeTeamId] AS [PlayerId],
						[HistoryHome].[HomeTeamId] AS [TeamId],
						[HistoryHome].[GoalsHomeTeam] AS [GoalsScored],
						[HistoryHome].[GoalsAwayTeam] AS [GoalsRecieved],
						[HistoryHome].[GameType] AS [GameType],
						[HistoryHome].[ResultKindHomeTeam] AS [ResultKindTeam],
						[HistoryHome].[GameDateUTC] AS [GameDateUTC],
						[HistoryHome].[CreatedUTC] AS [CreatedUTC],
						[HistoryHome].[ModifiedUTC] AS [ModifiedUTC]
					FROM [PrackaCup].[dbo].[Histories] AS [HistoryHome]
				)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW PlayerHistoriesView");
        }
    }
}
