import BostonBruinsEmblem from './boston-bruins-emblem/boston-bruins-emblem'
import BuffaloSabresEmblem from './buffalo-sabres-emblem/buffalo-sabres-emblem'
import PhiladelphiaFlyersEmblem from './philadephia-flyers-emblem/philadephia-flyers-emblem'
import {
    BOSTON_BRUINS,
    BUFFALO_SABRES,
    PHILADELPHIA_FLYERS,
    PossibleEmblems
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
