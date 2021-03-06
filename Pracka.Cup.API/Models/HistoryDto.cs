﻿namespace Pracka.Cup.API.Models
{
    using Pracka.Cup.Database.Enums;
    using System;

    public class HistoryDto
    {
        public int Id { get; set; }
        public TeamDto HomeTeam { get; set; }
        public PlayerDto PlayerHomeTeam { get; set; }
        public int GoalsHomeTeam { get; set; }

        public TeamDto AwayTeam { get; set; }
        public PlayerDto PlayerAwayTeam { get; set; }
        public int GoalsAwayTeam { get; set; }

        public GameTypeEnum GameType { get; set; }
        public DateTime GameDateUTC { get; set; }
        public DateTime CreatedUTC { get; set; }
        public DateTime ModifiedUTC { get; set; }
    }
}
