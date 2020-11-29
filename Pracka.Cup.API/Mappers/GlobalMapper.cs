namespace Pracka.Cup.API.Mappers
{
    using AutoMapper;

    internal class GlobalMapper
    {
        public static Mapper Activate()
        {
            IConfigurationProvider configurationProvider = new MapperConfiguration((configuration) =>
            {
                configuration.AddProfile<HistoryProfile>();
                configuration.AddProfile<PlayerProfile>();
                configuration.AddProfile<TeamProfile>();
            });
            //configurationProvider.CompileMappings();

            return new Mapper(configurationProvider);
        }
    }
}
