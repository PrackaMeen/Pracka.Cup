import { BOSTON_BRUINS, BUFFALO_SABRES, PHILADELPHIA_FLYERS } from "../../components/emblems/types"
import { HistoryViewModelType, HistoryViewModelRowType } from "../history-view-data"

const dummyHistoryViewModelRow: HistoryViewModelRowType[] = [{
    key: `1`,
    leftTeam: BOSTON_BRUINS,
    rightTeam: BUFFALO_SABRES,
    score: '5-4pp'
}, {
    key: `2`,
    leftTeam: BUFFALO_SABRES,
    rightTeam: PHILADELPHIA_FLYERS,
    score: '3-7'
}, {
    key: `3`,
    leftTeam: PHILADELPHIA_FLYERS,
    rightTeam: BOSTON_BRUINS,
    score: '10-0'
}, {
    key: `4`,
    leftTeam: BUFFALO_SABRES,
    rightTeam: BOSTON_BRUINS,
    score: '12-11pp'
}, {
    key: `5`,
    leftTeam: BOSTON_BRUINS,
    rightTeam: PHILADELPHIA_FLYERS,
    score: '12-13pn'
}, {
    key: `6`,
    leftTeam: PHILADELPHIA_FLYERS,
    rightTeam: BUFFALO_SABRES,
    score: '1-3'
}]

export const dummyHistoryViewModel: HistoryViewModelType[] = [{
    date: new Date(2020, 10, 21, 18, 40, 45),
    rows: dummyHistoryViewModelRow
}, {
    date: new Date(2020, 10, 21, 18, 30, 45),
    rows: dummyHistoryViewModelRow
}, {
    date: new Date(2020, 10, 21, 17, 30, 45),
    rows: dummyHistoryViewModelRow
}, {
    date: new Date(2020, 10, 21, 15, 30, 45),
    rows: dummyHistoryViewModelRow
}, {
    date: new Date(2020, 10, 20, 16, 30, 45),
    rows: dummyHistoryViewModelRow
}, {
    date: new Date(2020, 10, 19),
    rows: dummyHistoryViewModelRow
}]