namespace Pracka.Cup.API.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.API.Services.Abstractions;
    using Pracka.Cup.Database;
    using Pracka.Cup.Database.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TeamsService : ITeamsService
    {
        private readonly CupContext _context;
        private readonly IMapper _mapper;

        public TeamsService(CupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamDto> CreateTeam(CreateTeamDto createTeamDto)
        {
            if (false == isModelValid(createTeamDto))
            {
                throw new ArgumentException();
            }

            var teamToCreate = _mapper.Map<CreateTeamDto, TeamModel>(createTeamDto);
            teamToCreate.Created = teamToCreate.Modified = DateTime.UtcNow;

            var createdTeam = await _context.Teams.AddAsync(teamToCreate);

            var teamDto = _mapper.Map<TeamModel, TeamDto>(createdTeam.Entity);
            return teamDto;
        }
        public async Task<TeamDto> GetTeamBy(int id)
        {
            var foundTeam = await _context.Teams.FirstOrDefaultAsync((team) => id == team.Id);
            var foundTeamDto = _mapper.Map<TeamModel, TeamDto>(foundTeam);
            return foundTeamDto;
        }
        public async Task<IEnumerable<TeamDto>> GetAllTeams()
        {
            var foundTeams = await _context.Teams.ToArrayAsync();
            var foundTeamsDtos = _mapper.Map<TeamModel[], TeamDto[]>(foundTeams);
            return foundTeamsDtos;
        }

        private bool isModelValid(CreateTeamDto createTeamDto)
        {
            return true;
        }
    }
}
