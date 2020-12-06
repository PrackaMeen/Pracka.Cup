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
            if (false == IsModelValid(createPlayerDto, out string issues))
            {
                throw new ArgumentException($"Player model is not valid. Issues: {issues}");
            }

            var selectedTeam = await _context.Teams.FirstAsync((team) => team.Id == createPlayerDto.SelectedTeamId);

            var playerToBeCreated = _mapper.Map<CreatePlayerDto, PlayerModel>(createPlayerDto);

            var createdPlayer = await _context.Players.AddAsync(playerToBeCreated);
            await _context.SaveChangesAsync();

            var playerDto = _mapper.Map<PlayerModel, PlayerDto>(createdPlayer.Entity);
            return playerDto;
        }
        public async Task<PlayerDto> UpdatePlayer(int playerToBeUpdatedId, UpdatePlayerDto updatePlayerDto)
        {
            if (false == IsModelValid(updatePlayerDto, out string issues))
            {
                throw new ArgumentException($"Player model is not valid. Issues: {issues}");
            }

            var playerToBeUpdated = await _context.Players.FirstOrDefaultAsync((player) => playerToBeUpdatedId == player.Id);
            if (null != playerToBeUpdated)
            {
                if (null != updatePlayerDto.Id && updatePlayerDto.Id.HasValue)
                {
                    var newProposedPlayerId = updatePlayerDto.Id.Value;
                    if (playerToBeUpdatedId != newProposedPlayerId)
                    {
                        throw new NotImplementedException("Update of player Id is not yet implemented.");
                    }
                }
                if (null != updatePlayerDto.SelectedTeamId && updatePlayerDto.SelectedTeamId.HasValue)
                {
                    var newSelectedTeamId = updatePlayerDto.SelectedTeamId.Value;
                    var newlySelectedTeam = await _context.Teams.FirstOrDefaultAsync((team) => newSelectedTeamId == team.Id);
                    if (null == newlySelectedTeam)
                    {
                        throw new ArgumentOutOfRangeException($"Selected team with specified Id: {newSelectedTeamId} does not exist.");
                    }

                    playerToBeUpdated.SelectedTeam = newlySelectedTeam;
                    playerToBeUpdated.SelectedTeamId = newSelectedTeamId;
                }
                if (null != updatePlayerDto.LastName)
                {
                    playerToBeUpdated.LastName = updatePlayerDto.LastName;
                }
                if (null != updatePlayerDto.FirstName)
                {
                    playerToBeUpdated.FirstName = updatePlayerDto.FirstName;
                }
                if (null != updatePlayerDto.Nickname)
                {
                    playerToBeUpdated.Nickname = updatePlayerDto.Nickname;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Player with specified Id: {playerToBeUpdatedId} does not exist.");
            }

            playerToBeUpdated.ModifiedUTC = DateTime.UtcNow;
            var updatedPlayer = _context.Players.Update(playerToBeUpdated);
            var result = await _context.SaveChangesAsync();

            var playerDto = _mapper.Map<PlayerModel, PlayerDto>(updatedPlayer.Entity);
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

        private bool IsModelValid(CreatePlayerDto createPlayerDto, out string issues)
        {
            issues = "";
            return true;
        }
        private bool IsModelValid(UpdatePlayerDto updatePlayerDto, out string issues)
        {
            issues = "";
            return true;
        }
    }
}
