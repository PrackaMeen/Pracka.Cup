namespace Pracka.Cup.API.Mappers.Extensions
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;
    using System.Collections.Generic;

    public static class ScoreBoardModelMapperExtensions
    {
        public static ScoreBoardModel ToScoreBoardModel(
            this IMapper mapper,
            ScoreBoardDto scoreBoardDto)
        {
            var scoreBoardModel = mapper.Map<
                ScoreBoardDto,
                ScoreBoardModel
            >(scoreBoardDto);

            return scoreBoardModel;
        }

        public static ScoreBoardDto ToScoreBoardDto(
            this IMapper mapper,
            ScoreBoardModel scoreBoardModel)
        {
            var scoreBoardDto = mapper.Map<
                ScoreBoardModel,
                ScoreBoardDto
            >(scoreBoardModel);

            return scoreBoardDto;
        }

        public static IEnumerable<ScoreBoardModel> ToScoreBoardModels(
            this IMapper mapper,
            IEnumerable<ScoreBoardDto> scoreBoardDtos)
        {
            var scoreBoardModels = mapper.Map<
                IEnumerable<ScoreBoardDto>,
                IEnumerable<ScoreBoardModel>
            >(scoreBoardDtos);

            return scoreBoardModels;
        }

        public static IEnumerable<ScoreBoardDto> ToScoreBoardDtos(
            this IMapper mapper,
            IEnumerable<ScoreBoardModel> scoreBoardModels)
        {
            var scoreBoardDtos = mapper.Map<
                IEnumerable<ScoreBoardModel>,
                IEnumerable<ScoreBoardDto>
            >(scoreBoardModels);

            return scoreBoardDtos;
        }
    }
}
