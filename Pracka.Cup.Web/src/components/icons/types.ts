export type CommonIconProps = {
    className?: string
    style?: React.CSSProperties
}

export const FIRST_RANK = 'FIRST_RANK'
export const SECOND_RANK = 'SECOND_RANK'
export const THIRD_RANK = 'THIRD_RANK'
export const OTHER_RANK = 'OTHER_RANK'
export type PossibleRanks =
    | typeof FIRST_RANK
    | typeof SECOND_RANK
    | typeof THIRD_RANK
    | typeof OTHER_RANK
    
export const UP_ARROW = 'UP_ARROW'
export const DASH_ARROW = 'DASH_ARROW'
export const DOWN_ARROW = 'DOWN_ARROW'
export type PossibleArrows =
    | typeof UP_ARROW
    | typeof DASH_ARROW
    | typeof DOWN_ARROW