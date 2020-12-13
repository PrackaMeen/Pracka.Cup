import {
    PossibleEmblems
} from "../components/emblems/types"

export type GameStatsViewModelType = {
    userName: string
    iconType: PossibleEmblems
    hasWon: boolean
    actualRank: number
    oldRank: number
    classicGamesWon: number
    overtimesGamesWon: number
    shootoutGamesWon: number
}

export const CLASSIC = 'CLASSIC'
export const OVERTIME = 'OVERTIME'
export const SHOOTOUT = 'SHOOTOUT'
export type GameResultType =
    | typeof CLASSIC
    | typeof OVERTIME
    | typeof SHOOTOUT

export type GameResultViewModelType = {
    winnerStats: GameStatsViewModelType
    loserStats: GameStatsViewModelType
    gameType: GameResultType
}