import React from "react"
import { GameResultsViewProps } from "../types"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import { Button, makeStyles } from "@material-ui/core"
import clsx from "clsx"
import { BOSTON_BRUINS, PossibleEmblems } from "../../components/emblems/types"
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
        box: {},
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
            fontSize: '2.5em',
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

type UserStatsClasses = 'grid' | 'gridRow' | 'title' | 'titleEmblem' | 'box' | 'winner' | 'loser' | 'gridTitle'
function UserStats(props: {
    classes: Partial<Record<UserStatsClasses, string>>,
    currentGameType: GameResultType
}) {
    const { classes, currentGameType } = props

    function getBoxClass(args: {
        resultType: GameResultType,
        currentType: GameResultType,
        className?: string
    }) {
        return args.resultType === args.currentType
            ? clsx(classes.box, args.className)
            : classes.box
    }

    const numberOfWinGames = 52
    const numberOfWinAfterOvertimeGames = 8
    const numberOfWinAfterShootoutGames = 10

    return (
        <>
            <div className={classes.gridRow}>
                <TeamEmblem
                    className={classes.titleEmblem}
                    iconType={BOSTON_BRUINS}
                />
                <div className={classes.grid}>
                    <div className={classes.title}>Vyhra</div>
                    <div className={classes.title}>Marek</div>
                </div>
            </div>
            <div className={classes.gridRow}>
                <div className={classes.grid}>
                    <div className={classes.gridRow}>
                        <div className={classes.gridTitle}>Poradie</div>
                        <div className={classes.grid}>
                            <div>Pohar</div>
                            <div>Sipka</div>
                        </div>
                    </div>
                    <div className={classes.gridRow}>
                        <div>Bilancia:</div>
                    </div>
                    <div className={classes.gridRow}>
                        <GameBox
                            value={numberOfWinGames}
                            className={getBoxClass({
                                className: classes.winner,
                                resultType: 'CLASSIC',
                                currentType: currentGameType
                            })}
                        />
                        <div className={classes.box} >/</div>
                        <GameBox
                            value={numberOfWinAfterOvertimeGames}
                            className={getBoxClass({
                                className: classes.winner,
                                resultType: 'OVERTIME',
                                currentType: currentGameType
                            })}
                        />
                        <div className={classes.box} >/</div>
                        <GameBox
                            value={numberOfWinAfterShootoutGames}
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

type GameResultType = 'CLASSIC' | 'OVERTIME' | 'SHOOTOUT'
export default function GameResultsMobileView(props: GameResultsViewProps) {
    const classes = useStyles()
    const routerHistory = useHistory()

    const currentGameType: GameResultType = 'CLASSIC'

    return (
        <MobileSiteMenu>
            <div className={classes.grid}>
                <UserStats
                    classes={classes}
                    currentGameType={currentGameType}
                />
                <Button
                    className={classes.buttonAgain}
                    onClick={() => { routerHistory.push(organizeGameIndexRoute) }}
                >Hraj Znova
                </Button>
                <UserStats
                    classes={classes}
                    currentGameType={currentGameType}
                />
            </div>
        </MobileSiteMenu>
    )
}