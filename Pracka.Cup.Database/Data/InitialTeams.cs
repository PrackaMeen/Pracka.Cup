namespace Pracka.Cup.Database.Data
{
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class InitialTeams
    {
        public static TeamModel[] Get()
        {
            return new[]
            {
                new TeamModel()
                {
                    Id = 1,
                    CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                    ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                    Icon = "BUFFALO_SABRES",
                    Name = "Buffalo",
                },
                new TeamModel()
                {
                    Id = 2,
                    CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                    ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                    Icon = "BOSTON_BRUINS",
                    Name = "Boston",
                },
                new TeamModel()
                {
                    Id = 3,
                    CreatedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                    ModifiedUTC = new DateTime(2020,01,01,0,0,0,DateTimeKind.Utc),
                    Icon = "PHILADELPHIA_FLYERS",
                    Name = "Philadelpia",
                }
            };
        }
    }
}
