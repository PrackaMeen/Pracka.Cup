namespace Pracka.Cup.Database.DatabaseFunctions
{
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetLoss1ptStatisticsFunction : DatabaseTableFunctionBase<ScoreBoardModel>
    {
		public static string GetName()
        {
			return new GetLoss1ptStatisticsFunction().Name;

		}
		public override string Name => nameof(GetLoss1ptStatisticsFunction);

		public override string InnerQueryParameters => @"
			@lastHistoryId INT,
			@resultLoss INT,
			@typeOvertime INT,
			@typeShootout INT";

		public override string InnerQuery => @"
			SELECT
				0 as [TotalGames],
				0 as [Wins3ptsGames],
				0 as [Wins2ptsGames],
				Count([Loss1ptGamesTable].[PlayerId]) as [Loss1ptGames],
				0 as [Loss0ptsGames],
				0 as [TotalGoalsScored],
				0 as [TotalGoalsRecieved],
				[Loss1ptGamesTable].[PlayerId] as [PlayerId]

			FROM[PrackaCup].[dbo].[PlayerHistoriesView] as [Loss1ptGamesTable]

			WHERE[Loss1ptGamesTable].[ResultKindTeam] = @resultLoss
				AND (
					[Loss1ptGamesTable].[GameType] = @typeOvertime OR
					[Loss1ptGamesTable].[GameType] = @typeShootout
				)
				AND[Loss1ptGamesTable].[GameId] <= @lastHistoryId

			GROUP BY[Loss1ptGamesTable].[PlayerId]";
	}
}
