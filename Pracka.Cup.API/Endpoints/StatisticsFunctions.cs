namespace Pracka.Cup.API.Endpoints
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.API.Endpoints.Abstractions;
    using static Pracka.Cup.API.Endpoints.Constants.StatisticsEndpoints;
    using System.Collections.Generic;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.API.Services;
    using Microsoft.Extensions.Configuration;

    public class StatisticsFunctions : ApiFunctions, IStatisticsEndpoints
    {
        private readonly IPlayersService _playersService;
        private readonly IHistoriesService _historiesService;

        public StatisticsFunctions(IConfiguration configuration) : base(configuration)
        {
            _playersService = new PlayersService(base._context, base._mapper);
            _historiesService = new HistoriesService(base._context, base._mapper);
        }

        [FunctionName(nameof(GetAllStatistics))]
        public async Task<IActionResult> GetAllStatistics(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = STATISTICS)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllStatistics)}.");

                var allScoreBoards = await _historiesService.GetAllScoreBoards();

                var response = new ResponseModel<IEnumerable<ScoreBoardDto>>(allScoreBoards, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }
    }
}
