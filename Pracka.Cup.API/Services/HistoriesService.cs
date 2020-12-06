namespace Pracka.Cup.API.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.API.Mappers.Extensions;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.Database;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HistoriesService : IHistoriesService
    {
        private readonly CupContext _context;
        private readonly IMapper _mapper;

        public HistoriesService(CupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HistoryDto> CreateHistory(CreateHistoryDto createHistoryDto)
        {
            if (false == IsModelValid(createHistoryDto, out string issues))
            {
                throw new ArgumentException($"History model is not valid. Issues: {issues}");
            }

            var awayTeam = await _context.Teams
                .FirstOrDefaultAsync((team) => team.Id == createHistoryDto.AwayTeamId);
            var homeTeam = await _context.Teams
                .FirstOrDefaultAsync((team) => team.Id == createHistoryDto.HomeTeamId);

            var playerAwayTeam = await _context.Players
                .FirstOrDefaultAsync((player) => player.Id == createHistoryDto.PlayerAwayTeamId);
            var playerHomeTeam = await _context.Players
                .FirstOrDefaultAsync((player) => player.Id == createHistoryDto.PlayerHomeTeamId);

            if (null == createHistoryDto.GameDateUTC)
            {
                createHistoryDto.GameDateUTC = DateTime.UtcNow;
            }

            var historyToBeCreated = _mapper.ToHistoryModel(createHistoryDto);

            var createdHistory = await _context.Histories.AddAsync(historyToBeCreated);
            await _context.SaveChangesAsync();

            var historyDto = _mapper.ToHistoryDto(createdHistory.Entity);
            historyDto.AwayTeam = _mapper.Map<TeamModel, TeamDto>(awayTeam);
            historyDto.HomeTeam = _mapper.Map<TeamModel, TeamDto>(homeTeam);
            historyDto.PlayerAwayTeam = _mapper.Map<PlayerModel, PlayerDto>(playerAwayTeam);
            historyDto.PlayerHomeTeam = _mapper.Map<PlayerModel, PlayerDto>(playerHomeTeam);

            return historyDto;
        }
        public async Task<HistoryDto> GetHistoryBy(int id)
        {
            var foundHistory = await _context.Histories.FirstOrDefaultAsync((history) => id == history.Id);
            var foundHistoryDto = _mapper.ToHistoryDto(foundHistory);
            return foundHistoryDto;
        }
        private async Task<IEnumerable<HistoryDto>> GetAllHistories(bool withTeamsDetail, bool withPlayersDetail)
        {
            var foundHistories = await _context.Histories.ToArrayAsync();
            foreach (var foundHistory in foundHistories)
            {
                if (withTeamsDetail)
                {
                    foundHistory.AwayTeam = await _context.Teams
                        .FirstOrDefaultAsync((team) => foundHistory.AwayTeamId == team.Id);
                    foundHistory.HomeTeam = await _context.Teams
                        .FirstOrDefaultAsync((team) => foundHistory.HomeTeamId == team.Id);
                }
                if (withPlayersDetail)
                {
                    foundHistory.PlayerAwayTeam = await _context.Players
                        .FirstOrDefaultAsync((player) => foundHistory.PlayerAwayTeamId == player.Id);
                    foundHistory.PlayerHomeTeam = await _context.Players
                        .FirstOrDefaultAsync((player) => foundHistory.PlayerHomeTeamId == player.Id);
                }
            }

            var foundHistoriesDtos = foundHistories.Select(_mapper.ToHistoryDto);
            return foundHistoriesDtos;
        }
        public async Task<IEnumerable<HistoryDto>> GetAllHistories()
        {
            return await this.GetAllHistories(false, false);
        }

        public async Task<IEnumerable<HistoryDto>> GetAllHistoriesWithTeams()
        {
            return await this.GetAllHistories(true, false);
        }

        public async Task<IEnumerable<HistoryDto>> GetAllHistoriesWithPlayers()
        {
            return await this.GetAllHistories(false, true);
        }

        public async Task<IEnumerable<HistoryDto>> GetAllHistoriesWithAll()
        {
            return await this.GetAllHistories(true, true);
        }
        private bool IsModelValid(CreateHistoryDto createHistoryDto, out string issues)
        {
            issues = "";
            return true;
        }
    }
}
