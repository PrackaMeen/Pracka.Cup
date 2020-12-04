namespace Pracka.Cup.API.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.Database;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PlayersService : IPlayersService
    {
        private readonly CupContext _context;
        private readonly IMapper _mapper;

        public PlayersService(CupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlayerDto> CreatePlayer(CreatePlayerDto createPlayerDto)
        {
            if (false == isModelValid(createPlayerDto))
            {
                throw new ArgumentException();
            }

            var selectedTeam = await _context.Teams.FirstAsync((team) => team.Id == createPlayerDto.SelectedTeamId);

            var playerToBeCreated = _mapper.Map<CreatePlayerDto, PlayerModel>(createPlayerDto);
            playerToBeCreated.Created = playerToBeCreated.Modified = DateTime.UtcNow;

            var createdPlayer = await _context.Players.AddAsync(playerToBeCreated);

            var playerDto = _mapper.Map<PlayerModel, PlayerDto>(createdPlayer.Entity);
            return playerDto;
        }
        public async Task<PlayerDto> GetPlayerBy(int id)
        {
            var foundPlayer = await _context.Players.FirstOrDefaultAsync((player) => id == player.Id);
            var foundPlayerDto = _mapper.Map<PlayerModel, PlayerDto>(foundPlayer);
            return foundPlayerDto;
        }
        public async Task<IEnumerable<PlayerDto>> GetAllPlayers()
        {
            var foundPlayers = await _context.Players.ToArrayAsync();
            var foundPlayersDtos = _mapper.Map<PlayerModel[], PlayerDto[]>(foundPlayers);
            return foundPlayersDtos;
        }

        private bool isModelValid(CreatePlayerDto createPlayerDto)
        {
            return true;
        }
    }
}
