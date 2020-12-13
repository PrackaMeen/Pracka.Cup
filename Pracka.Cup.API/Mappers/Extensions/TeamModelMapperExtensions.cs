namespace Pracka.Cup.API.Mappers.Extensions
{
    using AutoMapper;
    using Pracka.Cup.API.Models;
    using Pracka.Cup.Database.Models;
    using Pracka.Cup.Database.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class HistoryModelMapperExtensions
    {
        private static TeamResultEnum GetHomeTeamResultByScore(int homeGoals, int awayGoals)
        {
            return homeGoals - awayGoals > 0 ? TeamResultEnum.VICTORY : TeamResultEnum.LOSS;
        }
        private static TeamResultEnum GetAwayTeamResultByScore(int homeGoals, int awayGoals)
        {
            return homeGoals - awayGoals < 0 ? TeamResultEnum.VICTORY : TeamResultEnum.LOSS;
        }

        public static HistoryModel ToHistoryModel(this IMapper mapper, CreateHistoryDto historyDto)
        {
            var historyModel = mapper.Map<CreateHistoryDto, HistoryModel>(historyDto);

            historyModel.ResultKindAwayTeam = GetAwayTeamResultByScore(historyModel.GoalsHomeTeam, historyModel.GoalsAwayTeam);
            historyModel.ResultKindHomeTeam = GetHomeTeamResultByScore(historyModel.GoalsHomeTeam, historyModel.GoalsAwayTeam);

            return historyModel;
        }

        public static HistoryModel ToHistoryModel(this IMapper mapper, HistoryDto historyDto)
        {
            var historyModel = mapper.Map<HistoryDto, HistoryModel>(historyDto);

            historyModel.ResultKindAwayTeam = GetAwayTeamResultByScore(historyModel.GoalsHomeTeam, historyModel.GoalsAwayTeam);
            historyModel.ResultKindHomeTeam = GetHomeTeamResultByScore(historyModel.GoalsHomeTeam, historyModel.GoalsAwayTeam);

            return historyModel;
        }

        public static HistoryDto ToHistoryDto(this IMapper mapper, HistoryModel historyModel)
        {
            var historyDto = mapper.Map<HistoryModel, HistoryDto>(historyModel);

            return historyDto;
        }
    }
}
