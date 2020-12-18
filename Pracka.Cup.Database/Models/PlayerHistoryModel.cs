namespace Pracka.Cup.Database.Models
{
    using Pracka.Cup.Database.Enums;
    using System;

    public class PlayerHistoryModel : EntityModel
    {
        public int GameId { get; set; }
        public int TeamId { get; set; }
        public virtual TeamModel Team { get; set; }
        public int PlayerId { get; set; }
        public virtual PlayerModel Player { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsRecieved { get; set; }
        public TeamResultEnum ResultKindTeam { get; set; }
        public GameTypeEnum GameType { get; set; }
        public DateTime GameDateUTC { get; set; }
    }
}
