export type CreateHistoryDto = {
    homeTeamId: number
    playerHomeTeamId: number
    goalsHomeTeam: number

    awayTeamId: number
    playerAwayTeamId: number
    goalsAwayTeam: number

    gameDateUTC: Date
}