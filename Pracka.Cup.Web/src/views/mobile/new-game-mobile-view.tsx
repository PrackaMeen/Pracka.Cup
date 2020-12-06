import React from "react"
import clsx from 'clsx'
import { NewGameViewProps } from "../types"
import { Box, Button, makeStyles, TextField, } from "@material-ui/core"
import { getEmblemByType } from "../../components/emblems/helpers"
import { PossibleEmblems } from "../../components/emblems/types"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import { GameType } from '../../api/models/game-type-enum'
import * as historiesService from "../../services/histories-service"

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
    scoreInput: {
        fontSize: '4em',
        width: '2em',
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

type WinButtonClasses = 'buttonEmblem' | 'buttonLabel'
const WinButton = (props: {
    label: string,
    emblemType?: PossibleEmblems,
    classes: Partial<Record<WinButtonClasses, string>>
    onClick: () => void
    disabled: boolean
}) => {
    const {
        label,
        emblemType,
        classes,
        onClick: handleClick,
        disabled
    } = props

    return (
        <Button
            classes={{
                label: classes?.buttonLabel
            }}
            startIcon={emblemType && getEmblemByType(emblemType)({
                className: classes?.buttonEmblem
            })}
            endIcon={emblemType && getEmblemByType(emblemType)({
                className: classes?.buttonEmblem
            })}
            onClick={handleClick}
            disabled={disabled}
        >
            <span style={{ width: '80%' }}>{label}</span>
        </Button>
    )
}

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
function isInputInvalid(value: number) {
    return true === isNegative(value)
}
function isClassicButtonValidation(leftValue: number, rightValue: number) {
    return isNegative(leftValue) || isNegative(rightValue)
        || leftValue === rightValue
}
function isNonClassicButtonValidation(leftValue: number, rightValue: number) {
    return isClassicButtonValidation(leftValue, rightValue)
        || 1 !== Math.abs(leftValue - rightValue)
}

export default function NewGameMobileView(props: NewGameViewProps) {
    const classes = useStyles()
    const [state, setState] = React.useState({ ...initialState })

    const winnerEmblem: PossibleEmblems | undefined
        = state.leftScoreValue > state.rightScoreValue
            ? state.leftEmblem
            : state.leftScoreValue < state.rightScoreValue
                ? state.rightEmblem
                : undefined

    React.useEffect(() => {
        console.log(state)
    })

    const leftEmblem = React.useMemo(() => {
        console.log('Rerender')
        return (
            <EmblemCarousel
                emblemType={state.leftEmblem}
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
                emblemType={state.rightEmblem}
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

            newHistory && setState((oldState) => {
                return {
                    ...oldState,
                    isLoading: false
                }
            })
        }

        return saveGame
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
                    <TextField
                        required={true}
                        error={isInputInvalid(state.leftScoreValue)}
                        type={'number'}
                        label={'Home'}
                        className={classes.rowLeft}
                        inputProps={{
                            className: clsx(classes.scoreInput, classes.textAlignRight)
                        }}
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder={'0'}
                        size='medium'
                        onChange={(event) => {
                            const value = Number(event.target.value)
                            setState((oldState) => {
                                return {
                                    ...oldState,
                                    leftScoreValue: value
                                }
                            })
                        }}
                    />
                    <div className={classes.rowCenter}>
                        :
                    </div>
                    <TextField
                        required={true}
                        error={isInputInvalid(state.rightScoreValue)}
                        type={'number'}
                        label={'Away'}
                        className={classes.rowRight}
                        inputProps={{
                            className: clsx(classes.scoreInput, classes.textAlignLeft)
                        }}
                        InputLabelProps={{
                            shrink: true,
                        }}
                        placeholder={'0'}
                        onChange={(event) => {
                            const value = Number(event.target.value)
                            setState((oldState) => {
                                return {
                                    ...oldState,
                                    rightScoreValue: value
                                }
                            })
                        }}
                    />
                </div>
                <Box style={{ display: 'grid' }}>
                    <WinButton
                        classes={{
                            buttonEmblem: classes.buttonEmblem,
                            buttonLabel: classes.buttonLabel
                        }}
                        label={'Vyhra'}
                        emblemType={winnerEmblem}
                        onClick={handleWinButtonClick(GameType.CLASSIC)}
                        disabled={isClassicButtonValidation(
                            state.leftScoreValue,
                            state.rightScoreValue
                        )}
                    />
                    <WinButton
                        classes={{
                            buttonEmblem: classes.buttonEmblem,
                            buttonLabel: classes.buttonLabel
                        }}
                        label={'Po predlzeni'}
                        emblemType={winnerEmblem}
                        onClick={handleWinButtonClick(GameType.OVERTIME)}
                        disabled={isNonClassicButtonValidation(
                            state.leftScoreValue,
                            state.rightScoreValue
                        )}
                    />
                    <WinButton
                        classes={{
                            buttonEmblem: classes.buttonEmblem,
                            buttonLabel: classes.buttonLabel
                        }}
                        label={'Po najazdoch'}
                        emblemType={winnerEmblem}
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