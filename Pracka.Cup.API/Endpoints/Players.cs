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
    using Pracka.Cup.Database.Models;

    public partial class ApiFunctions
    {
        const string PLAYERS = "players";
        const string GET_PLAYER_BY_ID = "players/{id}";
        const string CREATE_PLAYER = "players/create";

        Regex regexPlayerId = new Regex("players/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [FunctionName("GetAllPlayers")]
        public async Task<IActionResult> GetAllPlayers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = PLAYERS)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var allPlayers = _context.Players.ToList();

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = data,
                result = allPlayers
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName("GetPlayerById")]
        public async Task<IActionResult> GetPlayerById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_PLAYER_BY_ID)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexPlayerId, path, PLAYERS);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var player = _context.Players
                .FirstOrDefault((history) => history.Id == id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                data = data,
                result = player
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName("CreatePlayer")]
        public async Task<IActionResult> CreatePlayer(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_PLAYER)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexPlayerId, path, PLAYERS);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var playerData = JsonConvert.DeserializeObject<PlayerDto>(requestBody);

            var newPlayer = new PlayerModel()
            {
                FirstName = playerData.FirstName,
                LastName = playerData.LastName,
                Nickname = playerData.Nickname,
                SelectedTeamId = playerData.SelectedTeamId,
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };

            var craetedPlayer = _context.Players.Add(newPlayer);
            await _context.SaveChangesAsync();

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                data = playerData,
                result = craetedPlayer
            };

            return new OkObjectResult(responseObj);
        }
    }
}
