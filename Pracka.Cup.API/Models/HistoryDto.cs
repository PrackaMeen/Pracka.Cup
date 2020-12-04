namespace Pracka.Cup.API.Models
{
    using System;

    public class HistoryDto
    {
        public TeamDto HomeTeam { get; set; }
        public PlayerDto PlayerHomeTeam { get; set; }
        public int GoalsHomeTeam { get; set; }

        public TeamDto AwayTeam { get; set; }
        public PlayerDto PlayerAwayTeam { get; set; }
        public int GoalsAwayTeam { get; set; }

        public DateTime GameDate { get; set; }
    }
}
