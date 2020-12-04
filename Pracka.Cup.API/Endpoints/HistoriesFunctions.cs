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
    using static Pracka.Cup.API.Endpoints.Constants.HistoriesEndpoints;

    public partial class ApiFunctions : IHistoriesEndpoints
    {
        readonly Regex regexHistoryId = new Regex("histories/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [FunctionName(nameof(GetAllHistories))]
        public async Task<IActionResult> GetAllHistories(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = HISTORIES)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllHistories)}.");

            var allHistoryModels = await _context.Histories.ToArrayAsync();
            var allHistories = _mapper.Map<HistoryModel[], HistoryDto[]>(allHistoryModels);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                result = allHistories
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(GetHistoryById))]
        public async Task<IActionResult> GetHistoryById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_HISTORY_BY_ID)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetHistoryById)}.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexHistoryId, path, HISTORIES);

            var history = await _context.Histories
                .FirstOrDefaultAsync((history) => history.Id == id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                result = history
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(CreateHistory))]
        public async Task<IActionResult> CreateHistory(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_HISTORY)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(CreateHistory)}.");

            string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
            var createHistoryDto = JsonConvert.DeserializeObject<CreateHistoryDto>(requestBodyJson);

            if (null == createHistoryDto.GameDate)
            {
                createHistoryDto.GameDate = DateTime.UtcNow;
            }
            var newHistoryModel = _mapper.Map<CreateHistoryDto, HistoryModel>(createHistoryDto);
            newHistoryModel.ResultKindAwayTeam = Database.Enums.TeamResultEnum.Lost;    
            newHistoryModel.ResultKindHomeTeam = Database.Enums.TeamResultEnum.Victory;
            newHistoryModel.Modified = newHistoryModel.Created = DateTime.UtcNow;

            var createdHistory = await _context.Histories.AddAsync(newHistoryModel);
            await _context.SaveChangesAsync();

            var createdHistoryDto = _mapper.Map<HistoryModel, HistoryDto>(createdHistory.Entity);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = createHistoryDto,
                result = createdHistoryDto,
            };

            return new OkObjectResult(responseObj);
        }
    }
}
