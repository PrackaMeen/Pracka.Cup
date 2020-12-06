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
    using System.Collections.Generic;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.API.Services;
    using Microsoft.Extensions.Configuration;

    public class PlayersFunctions : ApiFunctions, IPlayersEndpoints
    {
        private readonly IPlayersService _playersService;
        readonly Regex regexPlayerId = new Regex("players/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public PlayersFunctions(IConfiguration configuration) : base(configuration)
        {
            _playersService = new PlayersService(base._context, base._mapper);
        }

        [FunctionName(nameof(GetAllPlayers))]
        public async Task<IActionResult> GetAllPlayers(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = PLAYERS)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllPlayers)}.");

                var allPlayerDtos = await _playersService.GetAllPlayers();

                var response = new ResponseModel<IEnumerable<PlayerDto>>(allPlayerDtos, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(GetPlayerById))]
        public async Task<IActionResult> GetPlayerById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = GET_PLAYER_BY_ID)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetPlayerById)}.");

                string path = req.Path.Value;
                int id = GetIdFromPathPart(regexPlayerId, path, PLAYERS);

                var playerDto = await _playersService.GetPlayerBy(id);

                var response = new ResponseModel<PlayerDto>(playerDto, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(CreatePlayer))]
        public async Task<IActionResult> CreatePlayer(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_PLAYER)] HttpRequest req,
           ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(CreatePlayer)}.");

                string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
                var createPlayerDto = JsonConvert.DeserializeObject<CreatePlayerDto>(requestBodyJson);

                var newPlayerDto = await _playersService.CreatePlayer(createPlayerDto);

                var response = new ResponseModel<PlayerDto, CreatePlayerDto>(newPlayerDto, req.Path, createPlayerDto);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }
        [FunctionName(nameof(UpdatePlayer))]
        public async Task<IActionResult> UpdatePlayer(
           [HttpTrigger(AuthorizationLevel.Function, "put", Route = UPDATE_PLAYER_WITH_ID)] HttpRequest req,
           ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(UpdatePlayer)}.");

                string path = req.Path.Value;
                int id = GetIdFromPathPart(regexPlayerId, path, PLAYERS);
                string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
                var updatePlayerDto = JsonConvert.DeserializeObject<UpdatePlayerDto>(requestBodyJson);

                var newPlayerDto = await _playersService.UpdatePlayer(id, updatePlayerDto);

                var response = new ResponseModel<PlayerDto, UpdatePlayerDto>(newPlayerDto, req.Path, updatePlayerDto);
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
