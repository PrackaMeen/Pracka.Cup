namespace Pracka.Cup.Database.Models
{
    using Pracka.Cup.Database.Enums;
    using System;

    public class HistoryModel : EntityModel
    {
        public TeamModel HomeTeam { get; set; }
        public PlayerModel PlayerHomeTeam { get; set; }
        public int GoalsHomeTeam { get; set; }
        public TeamResultEnum ResultKindHomeTeam { get; set; }

        public TeamModel AwayTeam { get; set; }
        public PlayerModel PlayerAwayTeam { get; set; }
        public int GoalsAwayTeam { get; set; }
        public TeamResultEnum ResultKindAwayTeam { get; set; }

        public DateTime GameDate { get; set; }
    }
}
