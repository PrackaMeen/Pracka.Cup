namespace Pracka.Cup.API.Endpoints.Abstractions
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using static Pracka.Cup.API.Endpoints.Constants.StatisticsEndpoints;

    public interface IStatisticsEndpoints
    {
        Task<IActionResult> GetAllStatistics(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = STATISTICS)] HttpRequest req,
            ILogger log);
    }
}
