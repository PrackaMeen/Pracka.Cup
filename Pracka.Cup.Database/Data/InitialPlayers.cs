﻿namespace Pracka.Cup.Database.Data
{
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class InitialPlayers
    {
        public static PlayerModel[] Get()
        {
            return new[]
            {
                new PlayerModel()
                {
                   Id = 1,
                   FirstName = "Main",
                   LastName = "Administrator",
                   Nickname = "Admin",
                   CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   SelectedTeamId = 1
                }, new PlayerModel()
                {
                   Id = 2,
                   FirstName = "Player",
                   LastName = "2",
                   Nickname = "Player2",
                   CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   SelectedTeamId = 1
                }, new PlayerModel()
                {
                   Id = 3,
                   FirstName = "Player",
                   LastName = "3",
                   Nickname = "Player3",
                   CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   SelectedTeamId = 2
                }, new PlayerModel()
                {
                   Id = 4,
                   FirstName = "Player",
                   LastName = "3",
                   Nickname = "Player3",
                   CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                   SelectedTeamId = 3
                }
            };
        }
    }
}
