namespace Pracka.Cup.Database.Data
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
                   FirstName = "Player",
                   LastName = "1",
                   Nickname = "Player1",
                   CreatedUTC = DateTime.UtcNow,
                   ModifiedUTC = DateTime.UtcNow,
                   SelectedTeamId = 2
                }, new PlayerModel()
                {
                   Id = 2,
                   FirstName = "Player",
                   LastName = "2",
                   Nickname = "Player2",
                   CreatedUTC = DateTime.UtcNow,
                   ModifiedUTC = DateTime.UtcNow,
                   SelectedTeamId = 1
                }, new PlayerModel()
                {
                   Id = 3,
                   FirstName = "Player",
                   LastName = "3",
                   Nickname = "Player3",
                   CreatedUTC = DateTime.UtcNow,
                   ModifiedUTC = DateTime.UtcNow,
                    SelectedTeamId = 3
                }
            };
        }
    }
}
