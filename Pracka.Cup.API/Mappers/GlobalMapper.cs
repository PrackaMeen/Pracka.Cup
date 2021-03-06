﻿namespace Pracka.Cup.API.Mappers
{
    using AutoMapper;
    using Pracka.Cup.API.Mappers.Profiles;

    internal class GlobalMapper
    {
        public static Mapper Activate()
        {
            IConfigurationProvider configurationProvider = new MapperConfiguration((configuration) =>
            {
                configuration.AddProfile<HistoryProfile>();
                configuration.AddProfile<PlayerProfile>();
                configuration.AddProfile<TeamProfile>();
                configuration.AddProfile<PlayerHistoryProfile>();
                configuration.AddProfile<ScoreBoardProfile>();
            });
            //configurationProvider.CompileMappings();

            return new Mapper(configurationProvider);
        }
    }
}
