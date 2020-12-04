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
    using static Pracka.Cup.API.Endpoints.Constants.TeamsEndpoints;

    public partial class ApiFunctions : ITeamsEndpoints
    {
        readonly Regex regexTeamId = new Regex("teams/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [FunctionName(nameof(GetAllTeams))]
        public async Task<IActionResult> GetAllTeams(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = TEAMS)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetAllTeams)}.");

            var allTeamDtos = await _teamsService.GetAllTeams();

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                result = allTeamDtos
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(GetTeamById))]
        public async Task<IActionResult> GetTeamById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_TEAM_BY_ID)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(GetTeamById)}.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexTeamId, path, TEAMS);

            var teamDto = await _teamsService.GetTeamBy(id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                result = teamDto
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName(nameof(CreateTeam))]
        public async Task<IActionResult> CreateTeam(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_TEAM)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request {nameof(CreateTeam)}.");

            string requestBodyJson = await new StreamReader(req.Body).ReadToEndAsync();
            var createTeamDto = JsonConvert.DeserializeObject<CreateTeamDto>(requestBodyJson);

            var newTeamDto = await _teamsService.CreateTeam(createTeamDto);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = createTeamDto,
                result = newTeamDto
            };

            return new OkObjectResult(responseObj);
        }
    }
}
