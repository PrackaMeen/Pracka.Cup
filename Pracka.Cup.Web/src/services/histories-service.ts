import * as historiesEndpoints from '../api/endpoints/histories-endpoints'
import { CreateHistoryDto } from '../api/models/create-history-dto'
import { GameType, getGameTypeEnum } from '../api/models/game-type-enum'
import { HistoryDto } from '../api/models/history-dto'
import { PossibleEmblems } from '../components/emblems/types'
import { GameResultViewModelType } from '../models/game-result-view-data'
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
    const allHistoriesDtos = await historiesEndpoints.getAllHistories()

    const historyViewModelRows = allHistoriesDtos.map(toHistoryViewModelType);

    return historyViewModelRows
}
export async function saveGameHistory(createHistory: CreateHistoryDto): Promise<HistoryDto | undefined> {
    createHistory.gameDateUTC = new Date()
    const newHistoryDto = await historiesEndpoints.createHistory(createHistory)

    return newHistoryDto
}

export async function getGameStatsHistoryBy(historyId: number): Promise<GameResultViewModelType | null> {
    const statsHistoryDtos = await historiesEndpoints.getGameHistoryStats(historyId)

    if (statsHistoryDtos) {
        const {
            gameHistory: {
                gameType
            },
            loserStats,
            winnerStats
        } = statsHistoryDtos

        const gameResultViewModel: GameResultViewModelType = {
            gameType: getGameTypeEnum(gameType),
            loserStats: {
                actualRank: loserStats.actualRank,
                classicGamesWon: loserStats.classicGamesWon,
                overtimesGamesWon: loserStats.overtimeGamesWon,
                shootoutGamesWon: loserStats.shootoutGamesWon,
                hasWon: false,
                iconType: loserStats.team.icon as PossibleEmblems,
                oldRank: loserStats.previousRank,
                userName: loserStats.player.nickname,
            },
            winnerStats:{
                actualRank: winnerStats.actualRank,
                classicGamesWon: winnerStats.classicGamesWon,
                overtimesGamesWon: winnerStats.overtimeGamesWon,
                shootoutGamesWon: winnerStats.shootoutGamesWon,
                hasWon: true,
                iconType: winnerStats.team.icon as PossibleEmblems,
                oldRank: winnerStats.previousRank,
                userName: winnerStats.player.nickname,
            }
        }

        return gameResultViewModel
    }

    return null
}