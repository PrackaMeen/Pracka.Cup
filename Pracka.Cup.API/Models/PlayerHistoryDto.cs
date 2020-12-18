namespace Pracka.Cup.API.Models
{
    using Pracka.Cup.Database.Enums;
    using System;

    public class PlayerHistoryDto
    {
        public int GameId { get; set; }
        public TeamDto Team { get; set; }
        public PlayerDto Player { get; set; }

        public int GoalsScored { get; set; }
        public int GoalsRecieved { get; set; }

        public GameTypeEnum GameType { get; set; }
        public TeamResultEnum ResultKindTeam { get; set; }

        public DateTime GameDateUTC { get; set; }
        public DateTime CreatedUTC { get; set; }
        public DateTime ModifiedUTC { get; set; }
    }
}
