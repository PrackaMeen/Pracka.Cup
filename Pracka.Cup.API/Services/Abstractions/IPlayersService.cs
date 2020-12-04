namespace Pracka.Cup.API.Services.Abstractions
{
    using Pracka.Cup.API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlayersService
    {
        Task<PlayerDto> CreatePlayer(CreatePlayerDto createPlayerDto);
        Task<IEnumerable<PlayerDto>> GetAllPlayers();
        Task<PlayerDto> GetPlayerBy(int id);
    }
}