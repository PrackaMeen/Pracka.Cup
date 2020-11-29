namespace Pracka.Cup.API.Mappers
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    internal class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerModel, PlayerDto>();
        }
    }
}
