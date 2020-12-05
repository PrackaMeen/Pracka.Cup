namespace Pracka.Cup.Database.Models
{
    using Pracka.Cup.Database.Enums;
    using System;

    public class HistoryModel : EntityModel
    {
        public int HomeTeamId { get; set; }
        public virtual TeamModel HomeTeam { get; set; }
        public int PlayerHomeTeamId { get; set; }
        public virtual PlayerModel PlayerHomeTeam { get; set; }
        public int GoalsHomeTeam { get; set; }
        public TeamResultEnum ResultKindHomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public virtual TeamModel AwayTeam { get; set; }
        public int PlayerAwayTeamId { get; set; }
        public virtual PlayerModel PlayerAwayTeam { get; set; }
        public int GoalsAwayTeam { get; set; }
        public TeamResultEnum ResultKindAwayTeam { get; set; }

        public DateTime GameDateUTC { get; set; }
    }
}
