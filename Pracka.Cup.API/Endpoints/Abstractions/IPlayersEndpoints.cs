namespace Pracka.Cup.API.Endpoints.Abstractions
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using static Pracka.Cup.API.Endpoints.Constants.PlayersEndpoints;

    public interface IPlayersEndpoints
    {
        Task<IActionResult> GetAllPlayers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = PLAYERS)] HttpRequest req,
            ILogger log);
        Task<IActionResult> GetPlayerById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_PLAYER_BY_ID)] HttpRequest req,
            ILogger log);
        Task<IActionResult> CreatePlayer(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_PLAYER)] HttpRequest req,
            ILogger log);
    }
}
