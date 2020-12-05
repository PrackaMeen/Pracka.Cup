﻿namespace Pracka.Cup.API.Services.Abstractions
{
    using Pracka.Cup.API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHistoriesService
    {
        Task<HistoryDto> CreateHistory(CreateHistoryDto createHistoryDto);
        Task<IEnumerable<HistoryDto>> GetAllHistories();
        Task<IEnumerable<HistoryDto>> GetAllHistoriesWithTeams();
        Task<IEnumerable<HistoryDto>> GetAllHistoriesWithPlayers();
        Task<IEnumerable<HistoryDto>> GetAllHistoriesWithAll();
        Task<HistoryDto> GetHistoryBy(int id);
    }
}