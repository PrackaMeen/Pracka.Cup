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
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Icon = "BOSTON_BRUINS",
                    Name = "Boston",
                },
                new TeamModel()
                {
                    Id = 2,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Icon = "BUFFALO_SABRES",
                    Name = "Buffalo",
                },
                new TeamModel()
                {
                    Id = 3,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Icon = "PHILADELPHIA_FLYERS",
                    Name = "Philadelpia",
                }
            };
        }
    }
}
