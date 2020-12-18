using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class ScoreBoard : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				-- ================================================
				-- Generated from EF Core
				-- ================================================
				CREATE OR ALTER FUNCTION GetScoreBoardBy
				(	
					@lastHistoryId INT
				)
				RETURNS TABLE 
				AS
				RETURN 
				(
					SELECT 
						SUM([Matches].[TotalGames]) as [TotalGames],
						SUM([Matches].[Loss1pt]) as [Loss1pt],
						SUM([Matches].[Wins2pts]) as [Wins2pts],
						SUM([Matches].[Wins3pts]) as [Wins3pts],
						[Matches].[PlayerId]
					FROM (
						(
							SELECT 
								COUNT([TotalGamesTable].[PlayerId]) as [TotalGames],
								0 as [Wins3pts], 
								0 as [Wins2pts], 
								0 as [Loss1pt], 
								[TotalGamesTable].[PlayerId] as [PlayerId]
							FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [TotalGamesTable]
							WHERE [TotalGamesTable].[GameId] <= @lastHistoryId
							GROUP BY [TotalGamesTable].[PlayerId]
						) UNION	(
							SELECT 
								0 as TotalGames, 
								3 * Count([Wins3ptsGamesTable].[PlayerId]) as [Wins3pts], 
								0 as [Wins2pts], 
								0 as [Loss1pt], 
								[Wins3ptsGamesTable].[PlayerId] as [PlayerId]
							FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [Wins3ptsGamesTable]
							WHERE [Wins3ptsGamesTable].[ResultKindTeam] = 1 
								AND [Wins3ptsGamesTable].[GameType] = 1 
								AND [Wins3ptsGamesTable].[GameId] <= @lastHistoryId
							GROUP BY [Wins3ptsGamesTable].[PlayerId]
						) UNION (
							SELECT 
								0 as [TotalGames], 
								0 as [Wins3pts],
								2 * Count([Wins2ptsGamesTable].[PlayerId]) as [Wins2pts], 
								0 as [Loss1pt], 
								[Wins2ptsGamesTable].[PlayerId] as [PlayerId]
							FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [Wins2ptsGamesTable]
							WHERE [Wins2ptsGamesTable].[ResultKindTeam] = 1 
								AND ([Wins2ptsGamesTable].[GameType] = 2 OR [Wins2ptsGamesTable].[GameType] = 3) 
								AND [Wins2ptsGamesTable].[GameId] <= @lastHistoryId
							GROUP BY [Wins2ptsGamesTable].[PlayerId]
						) UNION (
							SELECT 
								0 as [TotalGames], 
								0 as [Wins3pts],
								0 as [Wins2pts], 
								1 * Count([Loss1ptGamesTable].[PlayerId]) as [Loss1pt], 
								[Loss1ptGamesTable].[PlayerId] as [PlayerId]
							FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [Loss1ptGamesTable]
							WHERE [Loss1ptGamesTable].[ResultKindTeam] = 7 
								AND ([Loss1ptGamesTable].[GameType] = 2 OR [Loss1ptGamesTable].[GameType] = 3) 
								AND [Loss1ptGamesTable].[GameId] <= @lastHistoryId
							GROUP BY [Loss1ptGamesTable].[PlayerId]
						)
					) AS [Matches]
					GROUP BY [PlayerId]
				)");
			migrationBuilder.Sql(@"
				-- ================================================
				-- Generated from EF Core
				-- ================================================
				CREATE OR ALTER VIEW ScoreBoardView
				AS (
					SELECT *
					FROM [PrackaCup].[dbo].[GetScoreBoardBy](
						(SELECT MAX([Id]) FROM [PrackaCup].[dbo].[Histories])
					)
				)");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP FUNCTION GetScoreBoardBy");
			migrationBuilder.Sql("DROP VIEW ScoreBoardView");
		}
	}
}
