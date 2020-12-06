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
    using static Pracka.Cup.API.Endpoints.Constants.TeamsEndpoints;
    using System.Collections;
    using System.Collections.Generic;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.API.Services;
    using Microsoft.Extensions.Configuration;

    public class TeamsFunctions : ApiFunctions, ITeamsEndpoints
    {
        private readonly ITeamsService _teamsService;
        readonly Regex regexTeamId = new Regex("teams/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public TeamsFunctions(IConfiguration configuration) : base(configuration)
        {
            _teamsService = new TeamsService(base._context, base._mapper);
        }

        [FunctionName(nameof(GetAllTeams))]
        public async Task<IActionResult> GetAllTeams(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = TEAMS)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllTeams)}.");

                var allTeamDtos = await _teamsService.GetAllTeams();

                var response = new ResponseModel<IEnumerable<TeamDto>>(allTeamDtos, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(GetTeamById))]
        public async Task<IActionResult> GetTeamById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = GET_TEAM_BY_ID)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetTeamById)}.");

                string path = req.Path.Value;
                int id = GetIdFromPathPart(regexTeamId, path, TEAMS);

                var teamDto = await _teamsService.GetTeamBy(id);

                var response = new ResponseModel<TeamDto>(teamDto, req.Path);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "_");
                throw;
            }
        }

        [FunctionName(nameof(CreateTeam))]
        public async Task<IActionResult> CreateTeam(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_TEAM)] HttpRequest req,
           ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request {nameof(CreateTeam)}.");

                string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
                var createTeamDto = JsonConvert.DeserializeObject<CreateTeamDto>(requestBodyJson);

                var newTeamDto = await _teamsService.CreateTeam(createTeamDto);

                var response = new ResponseModel<TeamDto, CreateTeamDto>(newTeamDto, req.Path, createTeamDto);
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
