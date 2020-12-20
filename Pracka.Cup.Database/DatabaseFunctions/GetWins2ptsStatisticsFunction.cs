namespace Pracka.Cup.Database.DatabaseFunctions
{
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetWins2ptsStatisticsFunction : DatabaseTableFunctionBase<ScoreBoardModel>
	{
		public static string GetName()
		{
			return new GetWins2ptsStatisticsFunction().Name;

		}
		public override string Name => nameof(GetWins2ptsStatisticsFunction);

		public override string InnerQueryParameters => @"
			@lastHistoryId INT,
			@resultWin INT,
			@typeOvertime INT,
			@typeShootout INT";

		public override string InnerQuery => @"
			SELECT 
				0 as [TotalGames], 
				0 as [Wins3ptsGames],
				Count([Wins2ptsGamesTable].[PlayerId]) as [Wins2ptsGames], 
				0 as [Loss1ptGames], 
				0 as [Loss0ptsGames], 
				0 as [TotalGoalsScored],
				0 as [TotalGoalsRecieved],
				[Wins2ptsGamesTable].[PlayerId] as [PlayerId]

			FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [Wins2ptsGamesTable]

			WHERE [Wins2ptsGamesTable].[ResultKindTeam] = @resultWin 
				AND (
					[Wins2ptsGamesTable].[GameType] = @typeOvertime OR 
					[Wins2ptsGamesTable].[GameType] = @typeShootout
				) 
				AND [Wins2ptsGamesTable].[GameId] <= @lastHistoryId

			GROUP BY [Wins2ptsGamesTable].[PlayerId]";
	}
}
