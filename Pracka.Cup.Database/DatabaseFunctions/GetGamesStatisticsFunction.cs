namespace Pracka.Cup.Database.DatabaseFunctions
{
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetGamesStatisticsFunction : DatabaseTableFunctionBase<ScoreBoardModel>
    {
		public static string GetName()
		{
			return new GetGamesStatisticsFunction().Name;

		}
		public override string Name => nameof(GetGamesStatisticsFunction);

		public override string InnerQueryParameters => @"
			@lastHistoryId INT";

		public override string InnerQuery => $@"
			SELECT 
				COUNT([TotalGamesTable].[PlayerId]) as [TotalGames],
				0 as [Wins3ptsGames],
				0 as [Wins2ptsGames], 
				0 as [Loss1ptGames], 
				0 as [Loss0ptsGames], 
				SUM([TotalGamesTable].[GoalsScored]) as [TotalGoalsScored],
				SUM([TotalGamesTable].[GoalsRecieved]) as [TotalGoalsRecieved],
				[TotalGamesTable].[PlayerId] as [PlayerId]

			FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [TotalGamesTable]

			WHERE [TotalGamesTable].[GameId] <= @lastHistoryId

			GROUP BY [TotalGamesTable].[PlayerId]";
	}
}
