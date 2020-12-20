import { PlayerDto } from './player-dto'

export type StatisticsRankDto = {
    player: PlayerDto
    wins3ptsGames: number
    wins2ptsGames: number
    loss1ptGames: number
    loss0ptsGames: number
    totalPoints: number
    totalGames: number
    totalGoalsScored: number
    totalGoalsRecieved: number
    pointsPercentil: number
    rank: number
}