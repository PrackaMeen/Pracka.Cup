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
    using static Pracka.Cup.API.Endpoints.Constants.PlayersEndpoints;

    public partial class ApiFunctions : IPlayersEndpoints
    {
        readonly Regex regexPlayerId = new Regex("players/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [FunctionName(nameof(GetAllPlayers))]
        public async Task<IActionResult> GetAllPlayers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = PLAYERS)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllPlayers)}.");

            var allPlayerDtos = await _playersService.GetAllPlayers();

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                result = allPlayerDtos
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(GetPlayerById))]
        public async Task<IActionResult> GetPlayerById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_PLAYER_BY_ID)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetPlayerById)}.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexPlayerId, path, PLAYERS);

            var playerDto = await _playersService.GetPlayerBy(id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                result = playerDto
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(CreatePlayer))]
        public async Task<IActionResult> CreatePlayer(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_PLAYER)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(CreatePlayer)}.");

            string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
            var createPlayerDto = JsonConvert.DeserializeObject<CreatePlayerDto>(requestBodyJson);

            var newPlayerDto = await _playersService.CreatePlayer(createPlayerDto);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = createPlayerDto,
                result = newPlayerDto,
            };

            return new OkObjectResult(responseObj);
        }
    }
}
