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

            var allTeamModels = await _context.Teams.ToArrayAsync();
            var allTeams = _mapper.Map<TeamModel[], TeamDto[]>(allTeamModels);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                result = allTeams
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

            var teamModel = await _context.Teams
                .FirstOrDefaultAsync((history) => history.Id == id);

            var responseObj = new
            {
                arguments = new
                {
                    id = id,
                    all = req.Query.ToList()
                },
                result = _mapper.Map<TeamModel, TeamDto>(teamModel)
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
            var teamDto = JsonConvert.DeserializeObject<TeamDto>(requestBodyJson);

            var newTeam = new TeamModel()
            {
                Name = teamDto.Name,
                Icon = teamDto.Icon,
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };

            var createdTeam = await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();

            var createdTeamDto = _mapper.Map<TeamModel, TeamDto>(createdTeam.Entity);

            var responseObj = new
            {
                arguments = new
                {
                    all = req.Query.ToList()
                },
                data = teamDto,
                result = createdTeamDto
            };

            return new OkObjectResult(responseObj);
        }
    }
}
