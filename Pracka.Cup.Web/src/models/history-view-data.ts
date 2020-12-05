import { PossibleEmblems } from "../components/emblems/types"

export type TeamResultType = 'LOST' | 'LOST_OVERTIME' | 'LOST_SHOOTOUT' | 'WIN' | 'WIN_OVERTIME' | 'WIN_SHOOTOUT'
export type ResultType = 'CLASSIC' | 'OVERTIME' | 'SHOOTOUT'

export type HistoryViewModelRowType = {
    key: string
    leftTeam: PossibleEmblems
    rightTeam: PossibleEmblems
    score: string
}

export type HistoryViewModelType = {
    date: Date
    rows: HistoryViewModelRowType[]
}

export function toHistoryViewModelMapper() {

}
export function toHistoryViewModelRowMapper() {

}