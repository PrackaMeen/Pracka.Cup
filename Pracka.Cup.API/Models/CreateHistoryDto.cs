﻿namespace Pracka.Cup.API.Models
{
    using System;

    public class CreateHistoryDto
    {
        public int HomeTeamId { get; set; }
        public int PlayerHomeTeamId { get; set; }
        public int GoalsHomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public int PlayerAwayTeamId { get; set; }
        public int GoalsAwayTeam { get; set; }

        public DateTime? GameDate { get; set; }
    }
}
