namespace Pracka.Cup.API.Mappers.Profiles
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    internal class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerModel, PlayerDto>();
            CreateMap<CreatePlayerDto, PlayerModel>();
        }
    }
}
