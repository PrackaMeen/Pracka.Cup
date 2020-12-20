namespace Pracka.Cup.Database.DatabaseFunctions
{
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetCompleteStatisticsFunction : DatabaseTableFunctionBase<ScoreBoardModel>
    {
        public static string GetName()
        {
            return new GetCompleteStatisticsFunction().Name;

        }
        public override string Name => nameof(GetCompleteStatisticsFunction);

        public override string InnerQueryParameters => @"
			@lastHistoryId INT,
			@resultWin INT,
			@resultLoss INT,
			@typeClassic INT,
			@typeOvertime INT,
			@typeShootout INT";

        public override string InnerQuery => $@"
			SELECT 
				SUM([TotalGames]) AS [TotalGames],
				SUM([Wins3ptsGames]) AS [Wins3ptsGames],
				SUM([Wins2ptsGames]) AS [Wins2ptsGames], 
				SUM([Loss1ptGames]) AS [Loss1ptGames], 
				SUM([Loss0ptsGames]) AS [Loss0ptsGames], 
				SUM([TotalGoalsScored]) AS [TotalGoalsScored],
				SUM([TotalGoalsRecieved]) AS [TotalGoalsRecieved],
				[PlayerId]

			FROM (
				(
					SELECT * FROM [PrackaCup].[dbo].[{GetGamesStatisticsFunction.GetName()}](
						@lastHistoryId
					)
				) UNION	(
					SELECT * FROM [PrackaCup].[dbo].[{GetWins3ptsStatisticsFunction.GetName()}](
						@lastHistoryId,
						@resultWin,
						@typeClassic
					)	
				) UNION (
					SELECT * FROM [PrackaCup].[dbo].[{GetWins2ptsStatisticsFunction.GetName()}](
						@lastHistoryId,
						@resultWin,
						@typeOvertime,
						@typeShootout
					)	
				) UNION (
					SELECT * FROM [PrackaCup].[dbo].[{GetLoss1ptStatisticsFunction.GetName()}](
						@lastHistoryId,
						@resultLoss,
						@typeOvertime,
						@typeShootout
					)
				)
			) AS [CompleteStatistics]

			GROUP BY [CompleteStatistics].[PlayerId]";
    }
}
