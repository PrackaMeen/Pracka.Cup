import * as statisticsEndpoints from "../api/endpoints/statistics-endpoints";
import { StatisticViewModelType } from '../models/statistic-view-model'
import { PossibleEmblems } from "../components/emblems/types";

export async function getAllStatistics(): Promise<StatisticViewModelType[]> {
    const statisticsRankDtos = await statisticsEndpoints.getAllStatistics()

    const result = statisticsRankDtos.map<StatisticViewModelType>((statisticRank) => {
        return {
            games: statisticRank.totalGames,
            goalsObtained: statisticRank.totalGoalsRecieved,
            goalsScored: statisticRank.totalGoalsScored,
            loss0pts: statisticRank.loss0ptsGames,
            loss1pt: statisticRank.loss0ptsGames,
            wins2pts: statisticRank.wins2ptsGames,
            wins3pts: statisticRank.wins3ptsGames,
            rank: statisticRank.rank,
            overallPoints: statisticRank.totalPoints,
            user: {
                emblem: statisticRank.player.selectedTeam.icon as PossibleEmblems,
                nickname: statisticRank.player.nickname
            },
            pointsPercentil: statisticRank.pointsPercentil
        }
    })

    return result
}