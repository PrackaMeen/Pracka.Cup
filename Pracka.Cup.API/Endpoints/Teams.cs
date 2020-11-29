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
        const string TEAMS = "teams";
        const string GET_TEAM_BY_ID = "teams/{id}";
        const string CREATE_TEAM = "teams/create";

        Regex regexTeamId = new Regex("teams/\\d+/{0,1}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [FunctionName("GetAllTeams")]
        public async Task<IActionResult> GetAllTeams(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = TEAMS)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var allTeams = _context.Teams.ToList();

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = data,
                result = allTeams
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName("GetTeamById")]
        public async Task<IActionResult> GetTeamById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = GET_TEAM_BY_ID)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexTeamId, path, PLAYERS);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var team = _context.Teams
                .FirstOrDefault((history) => history.Id == id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                data = data,
                result = team
            };

            return new OkObjectResult(responseObj);
        }

        [FunctionName("CreateTeam")]
        public async Task<IActionResult> CreateTeam(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = CREATE_TEAM)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string path = req.Path.Value;
            int id = GetIdFromPathPart(regexPlayerId, path, TEAMS);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var teamDto = JsonConvert.DeserializeObject<TeamDto>(requestBody);

            var newTeam = new TeamModel()
            {
                Name = teamDto.Name,
                Icon = teamDto.Icon,
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };

            var createdTeam = _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();

            var createdTeamDto = new TeamDto()
            {
                Id = createdTeam.Entity.Id,
                Icon = createdTeam.Entity.Icon,
                Name = createdTeam.Entity.Name
            };

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                data = teamDto,
                result = createdTeamDto
            };

            return new OkObjectResult(responseObj);
        }
    }
}
