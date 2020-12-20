namespace Pracka.Cup.Database.DatabaseFunctions
{
    using Pracka.Cup.Database.DatabaseFunctions.Abstractions;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetWins3ptsStatisticsFunction : DatabaseTableFunctionBase<ScoreBoardModel>
    {
		public static string GetName()
		{
			return new GetWins3ptsStatisticsFunction().Name;

		}
		public override string Name => nameof(GetWins3ptsStatisticsFunction);

        public override string InnerQueryParameters => @"
			@lastHistoryId INT,
			@resultWin INT,
			@typeClassic INT";

        public override string InnerQuery => @"
			SELECT 
				0 as [TotalGames], 
				Count([Wins3ptsGamesTable].[PlayerId]) as [Wins3ptsGames], 
				0 as [Wins2ptsGames], 
				0 as [Loss1ptGames], 
				0 as [Loss0ptsGames], 
				0 as [TotalGoalsScored],
				0 as [TotalGoalsRecieved],
				[Wins3ptsGamesTable].[PlayerId] as [PlayerId]

			FROM [PrackaCup].[dbo].[PlayerHistoriesView] as [Wins3ptsGamesTable]

			WHERE [Wins3ptsGamesTable].[ResultKindTeam] = @resultWin
				AND [Wins3ptsGamesTable].[GameType] = @typeClassic 
				AND [Wins3ptsGamesTable].[GameId] <= @lastHistoryId

			GROUP BY [Wins3ptsGamesTable].[PlayerId]";
    }
}
