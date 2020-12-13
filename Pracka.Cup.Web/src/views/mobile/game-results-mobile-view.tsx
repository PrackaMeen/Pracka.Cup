import React from 'react'
import { CLASSIC, GameResultType, GameResultViewModelType, OVERTIME, SHOOTOUT, GameStatsViewModelType } from '../../models/game-result-view-data'
import { GameResultsViewProps } from '../types'
import MobileSiteMenu from '../../components/mobile-site-menu/mobile-site-menu'
import { Button, makeStyles } from '@material-ui/core'
import clsx from 'clsx'
import { PossibleEmblems } from '../../components/emblems/types'
import { getEmblemByType } from '../../components/emblems/helpers'
import { useHistory, useParams } from 'react-router-dom'
import { index as organizeGameIndexRoute } from '../../routes/organize-game-routes'
import Divider from '@material-ui/core/Divider/Divider'
import {
    PossibleArrows, DASH_ARROW, UP_ARROW, DOWN_ARROW
} from '../../components/icons/types'
import { getRankArrowByType, getRankCupByActualRank } from '../../components/icons/helpers'
import { historiesService } from '../../services'
import CircularProgress from '@material-ui/core/CircularProgress/CircularProgress'

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
            left: '47%',
            fontSize: '1.4em'
        },
        statsDivider: {
            height: '0.1em',
            backgroundColor: 'black'
        },
        statsLabel: {
            position: 'relative',
            left: '0%',
            fontSize: '1.4em'
        },
        bilanceLabel: {
            left: '15%'
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
            height: '9em'
        },
        winner: {
            color: 'green'
        },
        loser: {
            color: 'red'
        },
        againButton: {
            margin: '0.3em 0em',
            fontSize: '2.2em',
            backgroundColor: '#e9e9e9',
            '&:hover': {
                backgroundColor: '#e9e9e9',
            }
        },
        cup: {
            width: '4em',
            height: '4.6em',
            position: 'relative',
            left: '45%',
            padding: '0 0.3em',

        }
    }
})

const TeamEmblem = (props: { iconType: PossibleEmblems, className?: string }) => {
    return getEmblemByType(props.iconType)({
        className: props.className
    })
}

const RankCup = (props: { currentRank: number, className?: string }) => {
    return getRankCupByActualRank(props.currentRank)({
        className: props.className
    })
}
const RelativeRankChange = (props: { currentRank: number, oldRank: number, className?: string }) => {
    const rankDifference = props.oldRank - props.currentRank
    const iconType: PossibleArrows = 0 === rankDifference
        ? DASH_ARROW
        : 0 < rankDifference
            ? UP_ARROW
            : DOWN_ARROW
    return getRankArrowByType(iconType)({ className: props.className })
}

type UserStatsClasses =
    | 'grid' | 'gridRow' | 'title' | 'titleEmblem' | 'bilanceLabel' | 'statsDivider'
    | 'statsLabel' | 'statsBox' | 'winner' | 'loser' | 'gridTitle' | 'cup' | 'svgBackground'
function UserGameStats(props: {
    titleLabel: string
    rankLabel: string
    bilanceLabel: string
    classes: Partial<Record<UserStatsClasses, string>>
    currentGameType: GameResultType
    model: GameStatsViewModelType
}) {
    const {
        classes,
        currentGameType,
        titleLabel: title,
        rankLabel: rank,
        bilanceLabel: bilance,
        model
    } = props

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
                    <Divider
                        variant={'middle'}
                        classes={{ middle: classes.statsDivider }}
                    />
                    <div className={classes.title}>{model.userName}</div>
                </div>
            </div>
            <div className={classes.gridRow}>
                <div className={classes.grid}>
                    <div className={classes.gridRow}>
                        <div className={classes.gridTitle}>{rank}</div>
                        <div className={classes.grid}>
                            <div className={classes.gridRow}>
                                <RankCup
                                    currentRank={model.actualRank}
                                    className={classes.cup}
                                />
                                <RelativeRankChange
                                    currentRank={model.actualRank}
                                    oldRank={model.oldRank}
                                    className={classes.cup}
                                />
                            </div>
                        </div>
                    </div>
                    <div className={classes.gridRow}>
                        <div className={clsx(classes.statsLabel, classes.bilanceLabel)}>
                            {bilance}
                        </div>
                        <GameBox
                            value={model.classicGamesWon}
                            className={getBoxClass({
                                className: model.hasWon
                                    ? classes.winner
                                    : classes.loser,
                                resultType: CLASSIC,
                                currentType: currentGameType
                            })}
                        />
                        <div className={classes.statsBox} >/</div>
                        <GameBox
                            value={model.overtimesGamesWon}
                            className={getBoxClass({
                                className: model.hasWon
                                    ? classes.winner
                                    : classes.loser,
                                resultType: OVERTIME,
                                currentType: currentGameType
                            })}
                        />
                        <div className={classes.statsBox} >/</div>
                        <GameBox
                            value={model.shootoutGamesWon}
                            className={getBoxClass({
                                className: model.hasWon
                                    ? classes.winner
                                    : classes.loser,
                                resultType: SHOOTOUT,
                                currentType: currentGameType
                            })}
                        />
                    </div>
                </div>
            </div>
        </>
    )
}

export default function GameResultsMobileView(props: GameResultsViewProps) {
    const classes = useStyles()
    const routerHistory = useHistory()
    const routerParams = useParams<{ gameId: string }>()

    const [gameResult, setGameResult] = React.useState<GameResultViewModelType | null>(null)

    React.useEffect(() => {
        const gameId = Number(routerParams.gameId)
        if (gameId && !Number.isNaN(gameId)) {
            const fetchData = async () => {
                let gameResultsModel = await historiesService.getGameStatsHistoryBy(gameId)
                console.log(gameResultsModel)

                // const gameResultsModel: GameResultViewModelType = {
                //     winnerStats: {
                //         userName: 'Marek',
                //         iconType: BOSTON_BRUINS,
                //         hasWon: true,
                //         actualRank: 1,
                //         oldRank: 2,
                //         classicGamesWon: 52,
                //         overtimesGamesWon: 10,
                //         shootoutGamesWon: 14
                //     },
                //     gameType: 'SHOOTOUT',
                //     loserStats: {
                //         userName: 'Pracka',
                //         iconType: BUFFALO_SABRES,
                //         hasWon: false,
                //         actualRank: 4,
                //         oldRank: 3,
                //         classicGamesWon: 42,
                //         overtimesGamesWon: 23,
                //         shootoutGamesWon: 32
                //     }
                // }

                setGameResult(gameResultsModel)
            }

            fetchData()
        }
    }, [routerParams.gameId])

    if (!gameResult) {
        return (
            <MobileSiteMenu>
                <CircularProgress />
            </MobileSiteMenu>
        )
    }

    return (
        <MobileSiteMenu>
            <div className={classes.grid}>
                <UserGameStats
                    titleLabel={'Vyhra'}
                    rankLabel={'Poradie'}
                    bilanceLabel={'Bilancia:'}
                    classes={classes}
                    currentGameType={gameResult.gameType}
                    model={gameResult.winnerStats}
                />
                <Button
                    className={classes.againButton}
                    onClick={() => { routerHistory.push(organizeGameIndexRoute) }}
                >
                    {'Hraj Znova'}
                </Button>
                <UserGameStats
                    titleLabel={'Prehra'}
                    rankLabel={'Poradie'}
                    bilanceLabel={'Bilancia:'}
                    classes={classes}
                    currentGameType={gameResult.gameType}
                    model={gameResult.loserStats}
                />
            </div>
        </MobileSiteMenu>
    )
}