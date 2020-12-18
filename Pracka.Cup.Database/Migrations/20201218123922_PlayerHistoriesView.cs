using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class PlayerHistoriesView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW [dbo].[PlayerHistoriesView]
                AS
                SELECT
                    ISNULL([HistoryHome].[Id], [HistoryAway].[Id]) AS [GameId],
                    ISNULL([HistoryHome].[PlayerHomeTeamId], [HistoryAway].[PlayerAwayTeamId]) AS [PlayerId],
                    ISNULL([HistoryHome].[HomeTeamId], [HistoryAway].[AwayTeamId]) AS [TeamId],
                    ISNULL([HistoryHome].[GoalsHomeTeam], [HistoryAway].[GoalsAwayTeam]) AS [GoalsScored],
                    ISNULL([HistoryHome].[GoalsAwayTeam], [HistoryAway].[GoalsHomeTeam]) AS [GoalsRecieved],
                    ISNULL([HistoryHome].[GameType], [HistoryAway].[GameType]) AS [GameType],
                    ISNULL([HistoryHome].[ResultKindHomeTeam],[HistoryAway].[ResultKindAwayTeam]) AS [ResultKindTeam],
                    ISNULL([HistoryHome].[GameDateUTC],[HistoryAway].[GameDateUTC]) AS [GameDateUTC],
                    ISNULL([HistoryHome].[CreatedUTC],[HistoryAway].[CreatedUTC]) AS [CreatedUTC],
                    ISNULL([HistoryHome].[ModifiedUTC],[HistoryAway].[ModifiedUTC]) AS [ModifiedUTC]
                FROM[PrackaCup].[dbo].[Histories] AS [HistoryHome]
                FULL JOIN [PrackaCup].[dbo].[Histories] AS [HistoryAway] ON (
                    [HistoryHome].[PlayerHomeTeamId] = [HistoryAway].[PlayerAwayTeamId]
                    OR
                    [HistoryHome].[PlayerAwayTeamId] = [HistoryAway].[PlayerHomeTeamId]
                )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW PlayerHistoriesView");
        }
    }
}
