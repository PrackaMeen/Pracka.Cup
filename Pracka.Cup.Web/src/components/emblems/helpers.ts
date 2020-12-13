import { DashIcon, DownArrowIcon, RankCupIcon, UpArrowIcon } from '../icons'
import BostonBruinsEmblem from './boston-bruins-emblem/boston-bruins-emblem'
import BuffaloSabresEmblem from './buffalo-sabres-emblem/buffalo-sabres-emblem'
import PhiladelphiaFlyersEmblem from './philadephia-flyers-emblem/philadephia-flyers-emblem'
import {
    BOSTON_BRUINS,
    BUFFALO_SABRES,
    DASH_ARROW,
    DOWN_ARROW,
    FIRST_RANK,
    OTHER_RANK,
    PHILADELPHIA_FLYERS,
    PossibleArrows,
    PossibleEmblems,
    PossibleRanks,
    SECOND_RANK,
    THIRD_RANK,
    UP_ARROW
} from './types'

export function getEmblemByType(possibleEmblem: PossibleEmblems) {
    switch (possibleEmblem) {
        case BOSTON_BRUINS: {
            return BostonBruinsEmblem
        }
        case BUFFALO_SABRES: {
            return BuffaloSabresEmblem
        }
        case PHILADELPHIA_FLYERS: {
            return PhiladelphiaFlyersEmblem
        }

        default: {
            throw new Error('Argument missing or Invalid')
        }
    }
}

export function getRankCupByType(possibleRanks: PossibleRanks) {
    switch (possibleRanks) {
        case FIRST_RANK: {
            return RankCupIcon
        }
        case SECOND_RANK: {
            return RankCupIcon
        }
        case THIRD_RANK: {
            return RankCupIcon
        }
        case OTHER_RANK: {
            return RankCupIcon
        }

        default: {
            throw new Error('Argument missing or Invalid')
        }
    }
}

export function getRankArrowByType(possibleArrows: PossibleArrows) {
    switch (possibleArrows) {
        case DOWN_ARROW: {
            return DownArrowIcon
        }
        case DASH_ARROW: {
            return DashIcon
        }
        case UP_ARROW: {
            return UpArrowIcon
        }
        default: {
            throw new Error('Argument missing or Invalid')
        }
    }
}