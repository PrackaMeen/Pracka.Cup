namespace Pracka.Cup.Database.DatabaseFunctions
{
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetScoreBoardStatisticsFunction : DatabaseTableFunctionBase<ScoreBoardModel>
    {
        public static string GetName()
        {
            return new GetScoreBoardStatisticsFunction().Name;

        }
        public override string Name => nameof(GetScoreBoardStatisticsFunction);

        public override string InnerQueryParameters => @"
			@lastHistoryId INT,
			@resultWin INT,
			@resultLoss INT,
			@typeClassic INT,
			@typeOvertime INT,
			@typeShootout INT";

        public override string InnerQuery
        {
            get
            {
                var loss0ptsGamesQuery = "[TotalGames] - ([Wins3ptsGames] + [Wins2ptsGames] + [Loss1ptGames])";
				var totalPointsQuery = "[Loss1ptGames] + 2*[Wins2ptsGames] + 3*[Wins3ptsGames]";
				var pointsPercentilQuery = $"({totalPointsQuery}) / (3.0*[TotalGames])";

				return $@"
					SELECT 
						ROW_NUMBER() OVER (
							ORDER BY ({pointsPercentilQuery}) DESC
						) AS [Rank],
						[TotalGames],
						[Wins3ptsGames],
						[Wins2ptsGames],
						[Loss1ptGames],
						({loss0ptsGamesQuery}) as [Loss0ptsGames],
						({totalPointsQuery}) as [TotalPoints],
						({pointsPercentilQuery}) as [PointsPercentil],
						[TotalGoalsScored],
						[TotalGoalsRecieved],
						[PlayerId]

					FROM [PrackaCup].[dbo].[GetCompleteStatisticsFunction](
						@lastHistoryId,
						@resultWin,
						@resultLoss,
						@typeClassic,
						@typeOvertime,
						@typeShootout
					) AS [ScoreBoard]";
            }
        }
    }
}
