export enum GameType {
    CLASSIC = 1,
    OVERTIME = 2,
    SHOOTOUT = 3
}

export function getGameTypeEnum(gameType: GameType): 'CLASSIC' | 'OVERTIME' | 'SHOOTOUT' {
    switch (gameType) {
        case GameType.CLASSIC: {
            return 'CLASSIC'
        }
        case GameType.OVERTIME: {
            return 'OVERTIME'
        }
        case GameType.SHOOTOUT: {
            return 'SHOOTOUT'
        }
        default: {
            throw new Error('Argument exception')
        }
    }
}