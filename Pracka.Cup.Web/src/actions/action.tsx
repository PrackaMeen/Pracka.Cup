export const INCREASE_INDEX = 'INCREASE_INDEX'
export const DECREASE_INDEX = 'DECREASE_INDEX'

type DescreaseIndex = {
    type: typeof DECREASE_INDEX
    meta: {
        timestamp: number
    }
}

type IncreaseIndex = {
    type: typeof INCREASE_INDEX
    meta: {
        timestamp: number
    }
}

export type IndexActionTypes = DescreaseIndex | IncreaseIndex

export function decreaseIndex(): IndexActionTypes {
    return {
        type: DECREASE_INDEX,
        meta: {
            timestamp: Date.now()
        }
    }
}

export function increaseIndex(): IndexActionTypes {
    return {
        type: INCREASE_INDEX,
        meta: {
            timestamp: Date.now()
        }
    }
}