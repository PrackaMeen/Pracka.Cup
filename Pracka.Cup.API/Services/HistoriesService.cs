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
            if (false == isModelValid(createHistoryDto))
            {
                throw new ArgumentException();
            }

            var awayTeam = await _context.Teams
                .FirstOrDefaultAsync((team) => team.Id == createHistoryDto.AwayTeamId);
            var homeTeam = await _context.Teams
                .FirstOrDefaultAsync((team) => team.Id == createHistoryDto.HomeTeamId);

            var playerAwayTeam = await _context.Players
                .FirstOrDefaultAsync((player) => player.Id == createHistoryDto.PlayerAwayTeamId);
            var playerHomeTeam = await _context.Players
                .FirstOrDefaultAsync((player) => player.Id == createHistoryDto.PlayerHomeTeamId);

            if (null == createHistoryDto.GameDate)
            {
                createHistoryDto.GameDate = DateTime.UtcNow;
            }

            var historyToBeCreated = _mapper.Map<CreateHistoryDto, HistoryModel>(createHistoryDto);
            historyToBeCreated.Created = historyToBeCreated.Modified = DateTime.UtcNow;

            var createdHistory = await _context.Histories.AddAsync(historyToBeCreated);

            var historyDto = _mapper.Map<HistoryModel, HistoryDto>(createdHistory.Entity);
            historyDto.AwayTeam = _mapper.Map<TeamModel, TeamDto>(awayTeam);
            historyDto.HomeTeam = _mapper.Map<TeamModel, TeamDto>(homeTeam);
            historyDto.PlayerAwayTeam = _mapper.Map<PlayerModel, PlayerDto>(playerAwayTeam);
            historyDto.PlayerHomeTeam = _mapper.Map<PlayerModel, PlayerDto>(playerHomeTeam);

            return historyDto;
        }
        public async Task<HistoryDto> GetHistoryBy(int id)
        {
            var foundHistory = await _context.Histories.FirstOrDefaultAsync((history) => id == history.Id);
            var foundHistoryDto = _mapper.Map<HistoryModel, HistoryDto>(foundHistory);
            return foundHistoryDto;
        }
        public async Task<IEnumerable<HistoryDto>> GetAllHistories()
        {
            var foundHistories = await _context.Histories.ToArrayAsync();
            var foundHistoriesDtos = _mapper.Map<HistoryModel[], HistoryDto[]>(foundHistories);
            return foundHistoriesDtos;
        }

        private bool isModelValid(CreateHistoryDto createHistoryDto)
        {
            return true;
        }
    }
}
