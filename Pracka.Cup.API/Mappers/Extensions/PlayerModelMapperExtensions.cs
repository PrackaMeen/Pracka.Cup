namespace Pracka.Cup.API.Mappers.Extensions
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    public static class PlayerModelMapperExtensions
    {
        public static PlayerModel ToPlayerModel(this IMapper mapper, CreatePlayerDto createPlayerDto)
        {
            var playerModel = mapper.Map<CreatePlayerDto, PlayerModel>(createPlayerDto);
            return playerModel;
        }

        public static PlayerModel ToPlayerModel(this IMapper mapper, PlayerDto playerDto)
        {
            var playerModel = mapper.Map<PlayerDto, PlayerModel>(playerDto);
            return playerModel;
        }

        public static PlayerDto ToPlayerDto(this IMapper mapper, PlayerModel playerModel)
        {
            var playerDto = mapper.Map<PlayerModel, PlayerDto>(playerModel);
            return playerDto;
        }
    }
}
