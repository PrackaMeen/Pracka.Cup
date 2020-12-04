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
            [HttpTrigger(AuthorizationLevel.Function, "get", Route =  PLAYERS)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllPlayers)}.");

            var allPlayerModels = await _context.Players.ToArrayAsync();
            var allPlayers = _mapper.Map<PlayerModel[], PlayerDto[]>(allPlayerModels);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                result = allPlayers
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

            var playerModel = await _context.Players
                .FirstOrDefaultAsync((history) => history.Id == id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                result = _mapper.Map<PlayerModel, PlayerDto>(playerModel)
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
            var playerDto = JsonConvert.DeserializeObject<PlayerDto>(requestBodyJson);

            var selectedTeam = await _context.Teams.FirstOrDefaultAsync((team) => team.Id == playerDto.SelectedTeam.Id);
            if (null == selectedTeam)
            {
                return new NotFoundObjectResult(new
                {
                    message = "Not existing selected team"
                });
            }

            var newPlayer = new PlayerModel()
            {
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                Nickname = playerDto.Nickname,
                SelectedTeam = selectedTeam,
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };

            var createdPlayer = await _context.Players.AddAsync(newPlayer);
            await _context.SaveChangesAsync();
            var createdPlayerDto = _mapper.Map<PlayerModel, PlayerDto>(createdPlayer.Entity);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = playerDto,
                result = createdPlayerDto,
            };

            return new OkObjectResult(responseObj);
        }
    }
}
