namespace Pracka.Cup.API.Models
{
    using System;

    public class HistoryDto
    {
        public virtual TeamDto HomeTeam { get; set; }
        public virtual PlayerDto PlayerHomeTeam { get; set; }
        public int GoalsHomeTeam { get; set; }

        public virtual TeamDto AwayTeam { get; set; }
        public virtual PlayerDto PlayerAwayTeam { get; set; }
        public int GoalsAwayTeam { get; set; }

        public DateTime GameDate { get; set; }
    }
}
