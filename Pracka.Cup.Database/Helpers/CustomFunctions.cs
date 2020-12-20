namespace Pracka.Cup.Database.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.Database.DatabaseFunctions;
    using Pracka.Cup.Database.Enums;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Linq;
    using System.Text;

    public static class CustomFunctions
    {
        public static IQueryable<ScoreBoardModel> GetCompleteStatistics(
            this DbSet<ScoreBoardModel> scoreBoardDbSet,
            int lastHistoryId)
        {
            return scoreBoardDbSet.FromSqlRaw($@"
                    SELECT * FROM
                    [PrackaCup].[dbo].[{GetCompleteStatisticsFunction.GetName()}](
                        {lastHistoryId},
                        {(int)TeamResultEnum.VICTORY},
                        {(int)TeamResultEnum.LOSS},
                        {(int)GameTypeEnum.CLASSIC},
                        {(int)GameTypeEnum.OVERTIME},
                        {(int)GameTypeEnum.SHOOTOUT}
                    )");
        }
    }
}
