namespace Pracka.Cup.API.Services.Abstractions
{
    using Pracka.Cup.API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlayersService
    {
        Task<PlayerDto> CreatePlayer(CreatePlayerDto createPlayerDto);
        Task<PlayerDto> UpdatePlayer(int playerToBeUpdatedId, UpdatePlayerDto updatePlayerDto);
        Task<IEnumerable<PlayerDto>> GetAllPlayers();
        Task<PlayerDto> GetPlayerBy(int id);
    }
}