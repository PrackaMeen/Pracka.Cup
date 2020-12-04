namespace Pracka.Cup.API.Endpoints.Abstractions
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using static Pracka.Cup.API.Endpoints.Constants.HistoriesEndpoints;

    public interface IHistoriesEndpoints
    {
        Task<IActionResult> GetAllHistories(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = HISTORIES)] HttpRequest req,
            ILogger log);
        Task<IActionResult> GetHistoryById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_HISTORY_BY_ID)] HttpRequest req,
            ILogger log);
    }
}
