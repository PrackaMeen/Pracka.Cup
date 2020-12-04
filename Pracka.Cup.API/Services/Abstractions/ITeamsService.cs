namespace Pracka.Cup.API.Services.Abstractions
{
    using Pracka.Cup.API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamsService
    {
        Task<TeamDto> CreateTeam(CreateTeamDto createTeamDto);
        Task<IEnumerable<TeamDto>> GetAllTeams();
        Task<TeamDto> GetTeamBy(int id);
    }
}