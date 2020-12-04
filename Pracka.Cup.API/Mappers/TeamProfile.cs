namespace Pracka.Cup.API.Mappers
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    internal class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamModel, TeamDto>();
            CreateMap<CreateTeamDto, TeamModel>();
        }
    }
}
