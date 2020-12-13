namespace Pracka.Cup.API.Mappers.Extensions
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;

    public static class TeamModelMapperExtensions
    {
        public static TeamModel ToTeamModel(this IMapper mapper, CreateTeamDto createTeamDto)
        {
            var teamModel = mapper.Map<CreateTeamDto, TeamModel>(createTeamDto);
            return teamModel;
        }

        public static TeamModel ToTeamModel(this IMapper mapper, TeamDto teamDto)
        {
            var teamModel = mapper.Map<TeamDto, TeamModel>(teamDto);
            return teamModel;
        }

        public static TeamDto ToTeamDto(this IMapper mapper, TeamModel teamModel)
        {
            var teamModelDto = mapper.Map<TeamModel, TeamDto>(teamModel);
            return teamModelDto;
        }
    }
}
