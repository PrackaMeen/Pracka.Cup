import { PossibleEmblems } from "../components/emblems/types"

export type StatisticViewModelType = {
    rank: number
    user: {
        nickname: string
        emblem: PossibleEmblems
    }
    games: number
    wins3pts: number
    wins2pts: number
    loss1pt: number
    loss0pts: number
    goalsScored: number
    goalsObtained: number
    overallPoints: number
    pointsPercentil: number
}