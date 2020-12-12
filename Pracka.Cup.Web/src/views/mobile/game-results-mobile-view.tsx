import React from "react"
import { GameResultsViewProps } from "../types"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import { Button, makeStyles } from "@material-ui/core"
import clsx from "clsx"
import { BOSTON_BRUINS, BUFFALO_SABRES, PossibleEmblems } from "../../components/emblems/types"
import { getEmblemByType } from "../../components/emblems/helpers"
import { useHistory } from "react-router-dom"
import { index as organizeGameIndexRoute } from '../../routes/organize-game-routes'

function GameBox(props: { value: number, className?: string }) {
    const { value, className } = props
    return (
        <div className={className}>{value}</div>
    )
}

const useStyles = makeStyles(() => {
    return {
        statsBox: {
            position: 'relative',
            left: '50%',
            fontSize:'1.4em'
        },
        statsLabel: {
            position: 'relative',
            left: '0%',
            fontSize:'1.4em'
        },
        title: {
            fontSize: '3em',
            position: 'relative'
        },
        grid: {
            display: 'grid',
            width: '100%'
        },
        gridRow: {
            display: 'inline-flex'
        },
        gridTitle: {
            fontSize: '2.5em',
            position: 'relative'
        },
        titleEmblem: {
            position: 'relative',
            height: '10em'
        },
        winner: {
            color: 'green'
        },
        loser: {
            color: 'red'
        },
        buttonAgain: {
            margin: '0.3em 0em',
            fontSize: '2.2em',
            backgroundColor: '#e9e9e9',
            '&:hover': {
                backgroundColor: '#e9e9e9',
            }
        }
    }
})

const TeamEmblem = (props: { iconType: PossibleEmblems, className?: string }) => {
    return getEmblemByType(props.iconType)({ className: props.className })
}

type StatsModelType = {
    userName: string
    iconType: PossibleEmblems
}

type WinStatsModelType = {
    numberOfWinGamesAgainst: number
    numberOfWinAfterOvertimeGamesAgainst: number
    numberOfWinAfterShootoutGamesAgainst: number
} & StatsModelType
type LostStatsModelType = {
    numberOfLostGamesAgainst: number
    numberOfLostAfterOvertimeGamesAgainst: number
    numberOfLostAfterShootoutGamesAgainst: number
} & StatsModelType

type UserStatsClasses = 'grid' | 'gridRow' | 'title' | 'titleEmblem' | 'statsLabel' | 'statsBox' | 'winner' | 'loser' | 'gridTitle'
function UserStats(props: {
    title: string
    rank: string
    classes: Partial<Record<UserStatsClasses, string>>
    currentGameType: GameResultType
    model: StatsModelType & {
        classicGames: number
        overtimesGames: number
        shootoutGames: number
    }
}) {
    const { classes, currentGameType, title, rank, model } = props

    function getBoxClass(args: {
        resultType: GameResultType,
        currentType: GameResultType,
        className?: string
    }) {
        return args.resultType === args.currentType
            ? clsx(classes.statsBox, args.className)
            : classes.statsBox
    }

    return (
        <>
            <div className={classes.gridRow}>
                <TeamEmblem
                    className={classes.titleEmblem}
                    iconType={model.iconType}
                />
                <div className={classes.grid}>
                    <div className={classes.title}>{title}</div>
                    <div className={classes.title}>{model.userName}</div>
                </div>
            </div>
            <div className={classes.gridRow}>
                <div className={classes.grid}>
                    <div className={classes.gridRow}>
                        <div className={classes.gridTitle}>{rank}</div>
                        <div className={classes.grid}>
                            <div>Pohar</div>
                            <div>Sipka</div>
                        </div>
                    </div>
                    <div className={classes.gridRow}>
                        <div className={classes.statsLabel}>Bilancia:</div>
                        <GameBox
                            value={model.classicGames}
                            className={getBoxClass({
                                className: classes.winner,
                                resultType: 'CLASSIC',
                                currentType: currentGameType
                            })}
                        />
                        <div className={classes.statsBox} >/</div>
                        <GameBox
                            value={model.overtimesGames}
                            className={getBoxClass({
                                className: classes.winner,
                                resultType: 'OVERTIME',
                                currentType: currentGameType
                            })}
                        />
                        <div className={classes.statsBox} >/</div>
                        <GameBox
                            value={model.shootoutGames}
                            className={getBoxClass({
                                className: classes.winner,
                                resultType: 'SHOOTOUT',
                                currentType: currentGameType
                            })}
                        />
                    </div>
                </div>
            </div>
        </>
    )
}
function UserWinStats(props: {
    title: string
    rank: string
    classes: Partial<Record<UserStatsClasses, string>>
    currentGameType: GameResultType
    model: WinStatsModelType
}) {
    const { model } = props

    return (
        <UserStats
            {...props}
            model={{
                ...model,
                classicGames: model.numberOfWinGamesAgainst,
                overtimesGames: model.numberOfWinAfterOvertimeGamesAgainst,
                shootoutGames: model.numberOfWinAfterShootoutGamesAgainst
            }}
        />
    )
}
function UserLostStats(props: {
    title: string
    rank: string
    classes: Partial<Record<UserStatsClasses, string>>
    currentGameType: GameResultType
    model: LostStatsModelType
}) {
    const { model } = props

    return (
        <UserStats
            {...props}
            model={{
                ...model,
                classicGames: model.numberOfLostGamesAgainst,
                overtimesGames: model.numberOfLostAfterOvertimeGamesAgainst,
                shootoutGames: model.numberOfLostAfterShootoutGamesAgainst
            }}
        />
    )
}

type GameResultType = 'CLASSIC' | 'OVERTIME' | 'SHOOTOUT'
export default function GameResultsMobileView(props: GameResultsViewProps) {
    const classes = useStyles()
    const routerHistory = useHistory()

    const currentGameType: GameResultType = 'CLASSIC'

    return (
        <MobileSiteMenu>
            <div className={classes.grid}>
                <UserWinStats
                    title={'Vyhra'}
                    rank={'Poradie'}
                    classes={classes}
                    currentGameType={currentGameType}
                    model={{
                        userName: 'Marek',
                        iconType: BOSTON_BRUINS,
                        numberOfWinGamesAgainst: 52,
                        numberOfWinAfterOvertimeGamesAgainst: 10,
                        numberOfWinAfterShootoutGamesAgainst: 14
                    }}
                />
                <Button
                    className={classes.buttonAgain}
                    onClick={() => { routerHistory.push(organizeGameIndexRoute) }}
                >
                    Hraj Znova
                </Button>
                <UserLostStats
                    title={'Prehra'}
                    rank={'Poradie'}
                    classes={classes}
                    currentGameType={currentGameType}
                    model={{
                        userName: 'Pracka',
                        iconType: BUFFALO_SABRES,
                        numberOfLostGamesAgainst: 42,
                        numberOfLostAfterOvertimeGamesAgainst: 23,
                        numberOfLostAfterShootoutGamesAgainst: 32
                    }}
                />
            </div>
        </MobileSiteMenu>
    )
}