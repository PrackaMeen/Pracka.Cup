import { GameType } from "./game-type-enum";
import { PlayerDto } from "./player-dto";
import { TeamDto } from "./team-dto";

export type HistoryDto = {
    id: number
    homeTeam: TeamDto
    playerHomeTeam: PlayerDto
    goalsHomeTeam: number

    awayTeam: TeamDto
    playerAwayTeam: PlayerDto
    goalsAwayTeam: number

    gameDateUTC: Date
    gameType: GameType
}