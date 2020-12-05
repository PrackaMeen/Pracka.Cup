import * as historiesEndpoints from '../api/endpoints/histories-endpoints'
import { CreateHistoryDto } from '../api/models/create-history-dto'
import { GameType } from '../api/models/game-type-enum'
import { HistoryDto } from '../api/models/history-dto'
import { PossibleEmblems } from '../components/emblems/types'
import { HistoryViewModelType, HistoryViewModelRowType } from '../models/history-view-data'

function mapIconToEmblem(icon: string): PossibleEmblems {
    return icon as PossibleEmblems
}

function toHistoryViewModelRowType({
    id,
    gameType,
    goalsHomeTeam,
    homeTeam: { icon: homeTeamIcon },
    goalsAwayTeam,
    awayTeam: { icon: awayTeamIcon }
}: HistoryDto) {
    const nonClassic = GameType.CLASSIC === gameType
        ? ''
        : GameType.OVERTIME === gameType
            ? 'pp'
            : 'pn'
    var historyViewModelRow: HistoryViewModelRowType = {
        key: `${id}`,
        leftTeam: mapIconToEmblem(homeTeamIcon),
        score: `${goalsHomeTeam} - ${goalsAwayTeam}${nonClassic}`,
        rightTeam: mapIconToEmblem(awayTeamIcon)
    }

    return historyViewModelRow
}

function toHistoryViewModelType(historyDto: HistoryDto) {
    var historyViewModelRow = toHistoryViewModelRowType(historyDto)
    var historyViewModelType: HistoryViewModelType = {
        date: historyDto.gameDateUTC,
        rows: [historyViewModelRow]
    }

    return historyViewModelType
}

export async function getFullHistory(): Promise<HistoryViewModelType[]> {
    var allHistoriesDtos = await historiesEndpoints.getAllHistories()

    var historyViewModelRows = allHistoriesDtos.map(toHistoryViewModelType);

    return historyViewModelRows
}
export async function saveGameHistory(createHistory: CreateHistoryDto): Promise<HistoryDto | undefined> {
    createHistory.gameDateUTC = new Date()
    var newHistoryDto = await historiesEndpoints.createHistory(createHistory)

    return newHistoryDto
}