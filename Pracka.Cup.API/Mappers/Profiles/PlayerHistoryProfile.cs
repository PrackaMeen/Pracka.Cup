namespace Pracka.Cup.API.Mappers.Profiles
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    internal class PlayerHistoryProfile : Profile
    {
        public PlayerHistoryProfile()
        {
            CreateMap<PlayerHistoryModel, PlayerHistoryDto>();
        }
    }
}
