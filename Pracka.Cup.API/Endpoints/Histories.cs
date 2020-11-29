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
    using Pracka.Cup.Database;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Pracka.Cup.API.Models;

    public partial class ApiFunctions
    {
        const string HISTORIES = "histories";
        const string GET_HISTORY_BY_ID = "histories/{id}";

        Regex regexHistoryId = new Regex("histories/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [FunctionName(nameof(GetAllHistories))]
        public async Task<IActionResult> GetAllHistories(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = HISTORIES)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var allHistoryModels = _context.Histories.ToList();
            var allHistories = allHistoryModels.Select((historyModel) =>
            {
                return new HistoryDto()
                {
                    AwayTeam = _mapper.Map<TeamDto>(historyModel.AwayTeam),
                    HomeTeam = _mapper.Map<TeamDto>(historyModel.HomeTeam),
                    GoalsAwayTeam = historyModel.GoalsAwayTeam,
                    GoalsHomeTeam = historyModel.GoalsHomeTeam,
                    PlayerAwayTeam = _mapper.Map<PlayerDto>(historyModel.PlayerAwayTeam),
                    PlayerHomeTeam = _mapper.Map<PlayerDto>(historyModel.PlayerHomeTeam),
                    GameDate = historyModel.GameDate
                };
            });

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = data,
                result = allHistories
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(GetHistoryById))]
        public async Task<IActionResult> GetHistoryById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_HISTORY_BY_ID)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexHistoryId, path, HISTORIES);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var history = _context.Histories
                .FirstOrDefault((history) => history.Id == id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                data = data,
                result = history
            };

            return new OkObjectResult(responseObj);
        }
    }
}
