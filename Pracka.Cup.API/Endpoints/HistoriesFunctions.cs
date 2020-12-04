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

            var historyDtos = await _historiesService.GetAllHistories();

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                result = historyDtos
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

            var historyDto = await _historiesService.GetHistoryBy(id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                result = historyDto
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

            var newHistoryDto = await _historiesService.CreateHistory(createHistoryDto);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = createHistoryDto,
                result = newHistoryDto,
            };

            return new OkObjectResult(responseObj);
        }
    }
}
