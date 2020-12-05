export type CommonEmblemProps = {
    style?: React.CSSProperties,
    className?: string
}

export const BOSTON_BRUINS = 'BOSTON_BRUINS'
export const BUFFALO_SABRES = 'BUFFALO_SABRES'
export const PHILADELPHIA_FLYERS = 'PHILADELPHIA_FLYERS'
export type PossibleEmblems =
    | typeof BOSTON_BRUINS
    | typeof BUFFALO_SABRES
    | typeof PHILADELPHIA_FLYERS