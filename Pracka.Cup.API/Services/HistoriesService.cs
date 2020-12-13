namespace Pracka.Cup.API.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.API.Mappers.Extensions;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.Database;
    using Pracka.Cup.Database.Enums;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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

        public async Task<HistoryModel> GetHistoryModelBy(
            int id, bool withTeamsModel = false, bool withPlayersModel = false
        )
        {
            var foundHistory = await _context.Histories.FirstOrDefaultAsync((history) => id == history.Id);

            if (withTeamsModel)
            {
                foundHistory.PlayerHomeTeam = await _context.Players
                    .FirstOrDefaultAsync((player) => foundHistory.PlayerHomeTeamId == player.Id);
                foundHistory.PlayerAwayTeam = await _context.Players
                    .FirstOrDefaultAsync((player) => foundHistory.PlayerAwayTeamId == player.Id);
            }
            if (withPlayersModel)
            {
                foundHistory.HomeTeam = await _context.Teams
                    .FirstOrDefaultAsync((team) => foundHistory.HomeTeamId == team.Id);
                foundHistory.AwayTeam = await _context.Teams
                    .FirstOrDefaultAsync((team) => foundHistory.AwayTeamId == team.Id);
            }

            return foundHistory;
        }
        public async Task<HistoryDto> GetHistoryBy(int id, bool withTeamsDetail, bool withPlayersDetail)
        {
            var foundHistory = await this.GetHistoryModelBy(
                id, withTeamsModel: withTeamsDetail, withPlayersModel: withPlayersDetail
            );

            var foundHistoryDto = _mapper.ToHistoryDto(foundHistory);
            return foundHistoryDto;
        }
        public async Task<HistoryDto> GetHistoryBy(int id)
        {
            return await GetHistoryBy(id, false, false);
        }
        public async Task<HistoryDto> GetHistoryWithTeamsBy(int id)
        {
            return await GetHistoryBy(id, withTeamsDetail: true, withPlayersDetail: false);
        }
        public async Task<HistoryDto> GetHistoryWithPlayersBy(int id)
        {
            return await GetHistoryBy(id, withTeamsDetail: false, withPlayersDetail: true);
        }
        public async Task<HistoryDto> GetHistoryWithAllBy(int id)
        {
            return await GetHistoryBy(id, withTeamsDetail: true, withPlayersDetail: true);
        }

        private IQueryable<HistoryModel> GetHistoryModels(Expression<Func<HistoryModel, bool>> filter)
        {
            return _context.Histories.Where(filter);
        }
        private async Task<IEnumerable<HistoryModel>> GetAllHistoryModels(
            bool withTeamsModel = false, bool withPlayersModel = false
        )
        {
            var foundHistories = await _context.Histories.ToArrayAsync();
            foreach (var foundHistory in foundHistories)
            {
                if (withTeamsModel)
                {
                    foundHistory.AwayTeam = await _context.Teams
                        .FirstOrDefaultAsync((team) => foundHistory.AwayTeamId == team.Id);
                    foundHistory.HomeTeam = await _context.Teams
                        .FirstOrDefaultAsync((team) => foundHistory.HomeTeamId == team.Id);
                }
                if (withPlayersModel)
                {
                    foundHistory.PlayerAwayTeam = await _context.Players
                        .FirstOrDefaultAsync((player) => foundHistory.PlayerAwayTeamId == player.Id);
                    foundHistory.PlayerHomeTeam = await _context.Players
                        .FirstOrDefaultAsync((player) => foundHistory.PlayerHomeTeamId == player.Id);
                }
            }

            return foundHistories;
        }
        private async Task<IEnumerable<HistoryDto>> GetAllHistories(bool withTeamsDetail, bool withPlayersDetail)
        {
            var foundHistoryModels = await this.GetAllHistoryModels(
                withTeamsModel: withTeamsDetail,
                withPlayersModel: withPlayersDetail
            );

            var foundHistoriesDtos = foundHistoryModels.Select(_mapper.ToHistoryDto);
            return foundHistoriesDtos;
        }
        public async Task<IEnumerable<HistoryDto>> GetAllHistories()
        {
            return await this.GetAllHistories(withTeamsDetail: false, withPlayersDetail: false);
        }
        public async Task<IEnumerable<HistoryDto>> GetAllHistoriesWithTeams()
        {
            return await this.GetAllHistories(withTeamsDetail: true, withPlayersDetail: false);
        }
        public async Task<IEnumerable<HistoryDto>> GetAllHistoriesWithPlayers()
        {
            return await this.GetAllHistories(withTeamsDetail: false, withPlayersDetail: true);
        }
        public async Task<IEnumerable<HistoryDto>> GetAllHistoriesWithAll()
        {
            return await this.GetAllHistories(withTeamsDetail: true, withPlayersDetail: true);
        }

        public async Task<HistoryWithStatsDto> GetGameHistoryStatsBy(int id)
        {
            var historyModel = await this.GetHistoryModelBy(id);

            var player1Id = historyModel.PlayerAwayTeamId;
            var team1Id = historyModel.AwayTeamId;

            var player2Id = historyModel.PlayerHomeTeamId;
            var team2Id = historyModel.HomeTeamId;

            var winnerPlayerId = TeamResultEnum.VICTORY == historyModel.ResultKindHomeTeam
                ? historyModel.PlayerHomeTeamId
                : historyModel.PlayerAwayTeamId;
            var winnerTeamId = TeamResultEnum.VICTORY == historyModel.ResultKindHomeTeam
                ? historyModel.HomeTeamId
                : historyModel.AwayTeamId;

            var loserPlayerId = TeamResultEnum.LOSS == historyModel.ResultKindHomeTeam
                ? historyModel.PlayerHomeTeamId
                : historyModel.PlayerAwayTeamId;
            var loserTeamId = TeamResultEnum.LOSS == historyModel.ResultKindHomeTeam
                ? historyModel.HomeTeamId
                : historyModel.AwayTeamId;

            var allCommonHistory = await _context.Histories
                .Where((history) => id >= history.Id)
                .Where((history) => player1Id == history.PlayerAwayTeamId
                    || player2Id == history.PlayerAwayTeamId
                )
                .Where((history) => player1Id == history.PlayerHomeTeamId
                    || player2Id == history.PlayerHomeTeamId
                )
                .ToArrayAsync();

            //var allCommonHistory = allHistoryModels.Where((history) =>
            //{
            //    return (player1Id == history.PlayerAwayTeamId
            //        || player2Id == history.PlayerAwayTeamId)
            //        && (player1Id == history.PlayerHomeTeamId
            //        || player2Id == history.PlayerHomeTeamId);
            //});

            var winsForWinner = allCommonHistory.Where((commonHistory) =>
            {
                return commonHistory.IsWinner(winnerPlayerId);
            });
            var winsForLoser = allCommonHistory.Where((commonHistory) =>
            {
                return commonHistory.IsWinner(loserPlayerId);
            });

            var classicWinsForWinner = winsForWinner.NumberOfWinsBy(GameTypeEnum.CLASSIC);
            var overtimeWinsForWinner = winsForWinner.NumberOfWinsBy(GameTypeEnum.OVERTIME);
            var shootoutWinsForWinner = winsForWinner.NumberOfWinsBy(GameTypeEnum.SHOOTOUT);

            var classicWinsForLoser = winsForLoser.NumberOfWinsBy(GameTypeEnum.CLASSIC);
            var overtimeWinsForLoser = winsForLoser.NumberOfWinsBy(GameTypeEnum.OVERTIME);
            var shootoutWinsForLoser = winsForLoser.NumberOfWinsBy(GameTypeEnum.SHOOTOUT);

            var winnerPlayer = _context.Players.FirstOrDefault((player) => winnerPlayerId == player.Id);
            var winnerTeam = _context.Teams.FirstOrDefault((team) => winnerTeamId == team.Id);

            var loserPlayer = _context.Players.FirstOrDefault((player) => loserPlayerId == player.Id);
            var loserTeam = _context.Teams.FirstOrDefault((team) => loserTeamId == team.Id);

            var historyWithStatsDto = new HistoryWithStatsDto()
            {
                WinnerStats = new UserStatsDto()
                {
                    Player = _mapper.ToPlayerDto(winnerPlayer),
                    Team = _mapper.ToTeamDto(winnerTeam),
                    ClassicGamesWon = classicWinsForWinner,
                    OvertimeGamesWon = overtimeWinsForWinner,
                    ShootoutGamesWon = shootoutWinsForWinner
                },
                GameHistory = _mapper.ToHistoryDto(historyModel),
                LoserStats = new UserStatsDto()
                {
                    Player = _mapper.ToPlayerDto(loserPlayer),
                    Team = _mapper.ToTeamDto(loserTeam),
                    ClassicGamesWon = classicWinsForLoser,
                    OvertimeGamesWon = overtimeWinsForLoser,
                    ShootoutGamesWon = shootoutWinsForLoser
                },
            };

            return historyWithStatsDto;
        }

        private bool IsModelValid(CreateHistoryDto createHistoryDto, out string issues)
        {
            issues = "";
            return true;
        }
    }

    public static class LogicHelperExtensions
    {
        public static bool IsHomePlayer(this HistoryModel historyModel, int playerId)
        {
            return playerId == historyModel.PlayerHomeTeamId;
        }
        public static bool IsHomeWinner(this HistoryModel historyModel, int playerId)
        {
            return TeamResultEnum.VICTORY == historyModel.ResultKindHomeTeam
                && historyModel.IsHomePlayer(playerId);
        }

        public static bool IsAwayPlayer(this HistoryModel historyModel, int playerId)
        {
            return playerId == historyModel.PlayerAwayTeamId;
        }
        public static bool IsAwayWinner(this HistoryModel historyModel, int playerId)
        {
            return TeamResultEnum.VICTORY == historyModel.ResultKindAwayTeam
                && historyModel.IsAwayPlayer(playerId);
        }

        public static bool IsWinner(this HistoryModel historyModel, int playerId)
        {
            return historyModel.IsHomeWinner(playerId)
                || historyModel.IsAwayWinner(playerId);
        }

        public static int NumberOfWinsBy(this IEnumerable<HistoryModel> historyModels, GameTypeEnum gameType)
        {
            return historyModels.Count((historyModel) => gameType == historyModel.GameType);
        }
    }
}