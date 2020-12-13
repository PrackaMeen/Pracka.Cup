import {
    DashIcon, DownArrowIcon, UpArrowIcon,
    FirstRankCupIcon, SecondRankCupIcon, ThirdRankCupIcon, OtherRankCupIcon
} from '../icons'
import {
    PossibleArrows, DOWN_ARROW, DASH_ARROW, UP_ARROW, CommonIconProps
} from './types'

export function getRankCupByActualRank(actualRank: number) {
    switch (actualRank) {
        case 1: {
            return FirstRankCupIcon
        }
        case 2: {
            return SecondRankCupIcon
        }
        case 3: {
            return ThirdRankCupIcon
        }
        default: {
            return function (props: CommonIconProps) {
                const otherRankCupIcon = OtherRankCupIcon({
                    ...props,
                    rank: actualRank
                })

                return otherRankCupIcon
            }
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