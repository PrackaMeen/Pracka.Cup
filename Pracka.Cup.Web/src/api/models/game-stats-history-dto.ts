import { HistoryDto } from "./history-dto";
import { PlayerDto } from "./player-dto";
import { TeamDto } from "./team-dto";

export type UserGameStats = {
    player: PlayerDto
    team: TeamDto
    actualRank: number
    previousRank: number
    classicGamesWon: number
    overtimeGamesWon: number
    shootoutGamesWon: number
}
export type GameStatsHistoryDto = {
    gameHistory: HistoryDto
    winnerStats: UserGameStats
    loserStats: UserGameStats
}