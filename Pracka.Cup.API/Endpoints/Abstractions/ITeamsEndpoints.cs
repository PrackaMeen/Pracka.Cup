namespace Pracka.Cup.API.Endpoints.Abstractions
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using static Pracka.Cup.API.Endpoints.Constants.TeamsEndpoints;

    public interface ITeamsEndpoints
    {
        Task<IActionResult> GetAllTeams(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = TEAMS)] HttpRequest req,
            ILogger log);
        Task<IActionResult> GetTeamById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_TEAM_BY_ID)] HttpRequest req,
            ILogger log);
        Task<IActionResult> CreateTeam(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_TEAM)] HttpRequest req,
           ILogger log);
    }
}
