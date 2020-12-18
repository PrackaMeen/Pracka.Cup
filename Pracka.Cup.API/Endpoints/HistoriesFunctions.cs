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
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.API.Endpoints.Abstractions;
    using static Pracka.Cup.API.Endpoints.Constants.HistoriesEndpoints;
    using System.Collections.Generic;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.API.Services;
    using System.Linq.Expressions;
    using System.Web.Http;
    using Microsoft.Extensions.Configuration;

    public class HistoriesFunctions : ApiFunctions, IHistoriesEndpoints
    {
        private readonly IHistoriesService _historiesService;
        readonly Regex regexHistoryId = new Regex("histories/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public HistoriesFunctions(IConfiguration configuration) : base(configuration)
        {
            _historiesService = new HistoriesService(base._context, base._mapper);
        }

        [FunctionName(nameof(GetAllHistories))]
        public async Task<IActionResult> GetAllHistories(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = HISTORIES)] HttpRequest req,
           ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllHistories)}.");

                var historyDtos = await _historiesService.GetAllHistoriesWithAll();

                var response = new ResponseModel<IEnumerable<HistoryDto>>(historyDtos, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(BulkCreateHistories))]
        public async Task<IActionResult> BulkCreateHistories(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = HISTORIES)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(BulkCreateHistories)}.");
            try
            {
                string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
                var createHistoryDtos = JsonConvert.DeserializeObject<CreateHistoryDto[]>(requestBodyJson);

                var historyDtos = new List<HistoryDto>();
                foreach (var createHistoryDto in createHistoryDtos)
                {
                    var historyDto = await _historiesService.CreateHistory(createHistoryDto);
                    historyDtos.Add(historyDto);
                }

                var response = new ResponseModel<CreateHistoryDto[], HistoryDto[]>(createHistoryDtos, req.Path, historyDtos.ToArray());
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(GetHistoryById))]
        public async Task<IActionResult> GetHistoryById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = GET_HISTORY_BY_ID)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetHistoryById)}.");

                string path = req.Path.Value;
                int id = GetIdFromPathPart(regexHistoryId, path, HISTORIES);

                var historyDto = await _historiesService.GetHistoryBy(id);

                var response = new ResponseModel<HistoryDto>(historyDto, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(GetHistoryByIdWithStats))]
        public async Task<IActionResult> GetHistoryByIdWithStats(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = GET_HISTORY_BY_ID_WITH_STATS)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetHistoryById)}.");

                string path = req.Path.Value;
                int id = GetIdFromPathPart(regexHistoryId, path, HISTORIES);

                var historyWithStatsDto = await _historiesService.GetGameHistoryStatsBy(id);

                var response = new ResponseModel<HistoryWithStatsDto>(historyWithStatsDto, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(CreateHistory))]
        public async Task<IActionResult> CreateHistory(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_HISTORY)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(CreateHistory)}.");
            try
            {
                string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
                var createHistoryDto = JsonConvert.DeserializeObject<CreateHistoryDto>(requestBodyJson);

                var newHistoryDto = await _historiesService.CreateHistory(createHistoryDto);

                var response = new ResponseModel<HistoryDto, CreateHistoryDto>(newHistoryDto, req.Path, createHistoryDto);
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
