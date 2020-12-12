import React from "react"
import clsx from 'clsx'
import ScoreInput from '../../components/inputs/score-input'
import { NewGameViewProps } from "../types"
import { Box, makeStyles } from "@material-ui/core"
import { getEmblemByType } from "../../components/emblems/helpers"
import { PossibleEmblems } from "../../components/emblems/types"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import WinButton from "../../components/buttons/win-button"
import { GameType } from '../../api/models/game-type-enum'
import * as historiesService from "../../services/histories-service"
import { useHistory } from "react-router-dom"
import { getGameResultsRoute } from "../../routes/game-results-routes"

const useStyles = makeStyles((theme) => ({
    root: {
        '& > *': {
            margin: theme.spacing(1),
        },
    },
    title: {
        fontSize: '2em',
        textDecoration: 'underline'
    },
    versusRow: {
        display: 'flex'
    },
    rowLeft: {
        position: 'relative',
        left: '10%'
    },
    rowCenter: {
        fontSize: '3em',
        width: '80%',
        paddingTop: '0.2em'
    },
    rowRight: {
        position: 'relative',
        right: '10%'
    },
    rowEmblem: {
        height: '7em'
    },
    buttonEmblem: {
        height: '2.5em'
    },
    buttonLabel: {
        fontSize: '1.5em'
    },
    textAlignLeft: {
        textAlign: 'left'
    },
    textAlignRight: {
        textAlign: 'right'
    },
    text: {
        fontSize: '2em'
    }
}));

type EmblemCarouselClasses = 'emblem'
const EmblemCarousel = (props: {
    classes: Partial<Record<EmblemCarouselClasses, string>>
    emblemType: PossibleEmblems
    onClick(): void
    onDoubleClick(): void
}) => {
    const {
        classes,
        emblemType,
        onClick,
        onDoubleClick
    } = props

    let timeout: any = null
    return (
        <span
            onClick={function (event: React.MouseEvent<HTMLSpanElement, MouseEvent>) {
                if (!timeout) {
                    timeout = setTimeout(function () {
                        onClick()
                        timeout = null
                    }, 250)
                }
                else {
                    onDoubleClick()
                    clearTimeout(timeout)
                    timeout = null
                }
            }}
        >
            {getEmblemByType(emblemType)({
                className: classes?.emblem
            })}
        </span>
    )
}

const initialState = {
    isLoading: false,
    leftScoreValue: 0,
    leftEmblem: 'BUFFALO_SABRES' as PossibleEmblems,
    leftEmblemIndex: 0,
    rightScoreValue: 0,
    rightEmblem: 'BOSTON_BRUINS' as PossibleEmblems,
    rightEmblemIndex: 0,
    allEmblems: ['BUFFALO_SABRES', 'BOSTON_BRUINS', 'PHILADELPHIA_FLYERS'] as PossibleEmblems[]
}

function isNegative(value: number) {
    return 0 > value
}
function isClassicButtonValidation(leftValue: number, rightValue: number) {
    return isNegative(leftValue) || isNegative(rightValue)
        || leftValue === rightValue
}
function isNonClassicButtonValidation(leftValue: number, rightValue: number) {
    return isClassicButtonValidation(leftValue, rightValue)
        || 1 !== Math.abs(rightValue - leftValue)
}

function getWinnerEmblem(state: typeof initialState) {
    const winnerEmblem: PossibleEmblems | undefined
        = state.leftScoreValue > state.rightScoreValue
            ? state.leftEmblem
            : state.leftScoreValue < state.rightScoreValue
                ? state.rightEmblem
                : undefined

    return winnerEmblem
}
function getHomeEmblem(state: typeof initialState) {
    const homeEmblem: PossibleEmblems = state.leftEmblem

    return homeEmblem
}
function getAwayEmblem(state: typeof initialState) {
    const awayEmblem: PossibleEmblems = state.rightEmblem

    return awayEmblem
}

export default function NewGameMobileView(props: NewGameViewProps) {
    const classes = useStyles()
    const routerHistory = useHistory()

    const [state, setState] = React.useState({ ...initialState })

    React.useEffect(() => {
        console.log(state)
    })

    const leftEmblem = React.useMemo(() => {
        console.log('Rerender')
        return (
            <EmblemCarousel
                emblemType={getHomeEmblem(state)}
                onClick={() => {
                    console.log('Left emblem clicked')
                    setState((oldState) => {
                        const newTempLeftEmblemIndex = oldState.leftEmblemIndex + 1
                        const newLeftEmblemIndex = newTempLeftEmblemIndex > oldState.allEmblems.length - 1
                            ? 0
                            : newTempLeftEmblemIndex

                        return {
                            ...oldState,
                            leftEmblemIndex: newLeftEmblemIndex,
                            leftEmblem: oldState.allEmblems[newLeftEmblemIndex]
                        }
                    })
                }}
                onDoubleClick={() => {
                    console.log('Left emblem double clicked')
                    setState((oldState) => {
                        const newTempLeftEmblemIndex = oldState.leftEmblemIndex - 1
                        const newLeftEmblemIndex = newTempLeftEmblemIndex < 0
                            ? oldState.allEmblems.length - 1
                            : newTempLeftEmblemIndex

                        return {
                            ...oldState,
                            leftEmblemIndex: newLeftEmblemIndex,
                            leftEmblem: oldState.allEmblems[newLeftEmblemIndex]
                        }
                    })
                }}
                classes={{
                    emblem: clsx(classes.rowEmblem, classes.rowLeft),
                }}
            />
        )
    }, [state.leftEmblem, classes.rowEmblem, classes.rowLeft])
    const rightEmblem = React.useMemo(() => {
        console.log('Rerender')
        return (
            <EmblemCarousel
                emblemType={getAwayEmblem(state)}
                onClick={() => {
                    console.log('Right emblem clicked')
                    setState((oldState) => {
                        const newTempRightEmblemIndex = oldState.rightEmblemIndex + 1
                        const newRightEmblemIndex = newTempRightEmblemIndex > oldState.allEmblems.length - 1
                            ? 0
                            : newTempRightEmblemIndex

                        return {
                            ...oldState,
                            rightEmblemIndex: newRightEmblemIndex,
                            rightEmblem: oldState.allEmblems[newRightEmblemIndex]
                        }
                    })
                }}
                onDoubleClick={() => {
                    console.log('Right emblem double clicked')
                    setState((oldState) => {
                        const newTempRightEmblemIndex = oldState.rightEmblemIndex - 1
                        const newRightEmblemIndex = newTempRightEmblemIndex < 0
                            ? oldState.allEmblems.length - 1
                            : newTempRightEmblemIndex

                        return {
                            ...oldState,
                            rightEmblemIndex: newRightEmblemIndex,
                            rightEmblem: oldState.allEmblems[newRightEmblemIndex]
                        }
                    })
                }}
                classes={{
                    emblem: clsx(classes.rowEmblem, classes.rowRight),
                }}
            />
        )
    }, [state.rightEmblem, classes.rowEmblem, classes.rowRight])

    function handleWinButtonClick(gameType: GameType) {
        async function saveGame() {
            setState((oldState) => {
                return {
                    ...oldState,
                    isLoading: true
                }
            })
            const newHistory = await historiesService.saveGameHistory({
                gameDateUTC: new Date(),
                awayTeamId: 1,
                playerAwayTeamId: 1,
                goalsAwayTeam: state.rightScoreValue,
                homeTeamId: 2,
                playerHomeTeamId: 2,
                goalsHomeTeam: state.leftScoreValue,
                gameType,
            })

            if (newHistory) {
                setState((oldState) => {
                    return {
                        ...oldState,
                        isLoading: false
                    }
                })

                routerHistory.push(getGameResultsRoute({
                    gameId: newHistory.id
                }))
            } else {
                setState((oldState) => {
                    return {
                        ...oldState,
                        isLoading: false
                    }
                })
                prompt('Error during game creation')
            }
        }

        return saveGame
    }
    function handleHomeScoreChange(newHomeScore: number) {
        setState((oldState) => {
            return {
                ...oldState,
                leftScoreValue: newHomeScore
            }
        })
    }
    function handleAwayScoreChange(newAwayScore: number) {
        setState((oldState) => {
            return {
                ...oldState,
                rightScoreValue: newAwayScore
            }
        })
    }

    return (
        <MobileSiteMenu>
            <div>
                <div className={classes.title}>
                    Zapas:
                </div>
                <div className={classes.versusRow} >
                    {leftEmblem}
                    <span className={classes.rowCenter}                    >
                        vs
                    </span>
                    {rightEmblem}
                </div>

                <div className={classes.text}>
                    Score:
                </div>
                <div className={classes.versusRow} >
                    <ScoreInput
                        label={'Home'}
                        classes={{
                            rowSide: classes.rowLeft,
                            inputAlign: classes.textAlignRight
                        }}
                        onScoreChange={handleHomeScoreChange}
                        scoreValue={state.leftScoreValue}
                    />
                    <div className={classes.rowCenter}>
                        :
                    </div>
                    <ScoreInput
                        label={'Away'}
                        classes={{
                            rowSide: classes.rowRight,
                            inputAlign: classes.textAlignLeft
                        }}
                        onScoreChange={handleAwayScoreChange}
                        scoreValue={state.rightScoreValue}
                    />
                </div>
                <Box style={{ display: 'grid' }}>
                    <WinButton
                        label={'Vyhra'}
                        classes={classes}
                        emblemType={getWinnerEmblem(state)}
                        onClick={handleWinButtonClick(GameType.CLASSIC)}
                        disabled={isClassicButtonValidation(
                            state.leftScoreValue,
                            state.rightScoreValue
                        )}
                    />
                    <WinButton
                        label={'Po predlzeni'}
                        classes={classes}
                        emblemType={getWinnerEmblem(state)}
                        onClick={handleWinButtonClick(GameType.OVERTIME)}
                        disabled={isNonClassicButtonValidation(
                            state.leftScoreValue,
                            state.rightScoreValue
                        )}
                    />
                    <WinButton
                        label={'Po najazdoch'}
                        classes={classes}
                        emblemType={getWinnerEmblem(state)}
                        onClick={handleWinButtonClick(GameType.SHOOTOUT)}
                        disabled={isNonClassicButtonValidation(
                            state.leftScoreValue,
                            state.rightScoreValue
                        )}
                    />
                </Box>
            </div>
        </MobileSiteMenu>
    )
}