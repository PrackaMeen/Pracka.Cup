namespace Pracka.Cup.API.Services.Abstractions
{
    using Pracka.Cup.API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHistoriesService
    {
        Task<HistoryDto> CreateHistory(CreateHistoryDto createHistoryDto);
        Task<int> BulkCreateHistory(IEnumerable<CreateHistoryDto> createHistoryDto);


        Task<IEnumerable<HistoryDto>> GetAllHistories();
        Task<IEnumerable<HistoryDto>> GetAllHistoriesWithTeams();
        Task<IEnumerable<HistoryDto>> GetAllHistoriesWithPlayers();
        Task<IEnumerable<HistoryDto>> GetAllHistoriesWithAll();

        Task<HistoryDto> GetHistoryBy(int id);
        Task<HistoryDto> GetHistoryWithTeamsBy(int id);
        Task<HistoryDto> GetHistoryWithPlayersBy(int id);
        Task<HistoryDto> GetHistoryWithAllBy(int id);

        Task<HistoryWithStatsDto> GetGameHistoryStatsBy(int id);

        Task<IEnumerable<PlayerHistoryDto>> GetPlayerHistoriesBy(int personId);
    }
}