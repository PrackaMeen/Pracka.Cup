import React from "react"
import { LeagueRankViewProps } from "../types"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import { makeStyles } from "@material-ui/core/styles"
import { StatisticViewModelType } from '../../models/statistic-view-model'
import { getEmblemByType } from "../../components/emblems/helpers"
import { statisticsService } from '../../services'

const useStyles = makeStyles(() => {
    return {
        table: {
            display: 'inline-table',
            width: '100%'
        },
        tableRow: {
            display: 'table-row'
        },
        tableCell: {
            display: 'table-cell',
        },
        cellEmblem: {
            width: '1em'
        }
    }
})

function getTableRow(args: {
    columns: {
        rank: string | number
        user: JSX.Element
        games: string | number
        wins3pts: string | number
        wins2pts: string | number
        loss1pt: string | number
        loss0pts: string | number
        score: string
        overallPoints: string | number
        pointsPercentil: string
    }
    classes: Record<'tableRow' | 'tableCell', string>
}) {
    const {
        columns,
        classes
    } = args

    return (
        <div className={classes.tableRow} key={`${columns.rank}:${columns.overallPoints}`}>
            <div className={classes.tableCell}>{columns.rank}</div>
            <div className={classes.tableCell}>{columns.user}</div>
            <div className={classes.tableCell}>{columns.games}</div>
            <div className={classes.tableCell}>{columns.wins3pts}</div>
            <div className={classes.tableCell}>{columns.wins2pts}</div>
            <div className={classes.tableCell}>{columns.loss1pt}</div>
            <div className={classes.tableCell}>{columns.loss0pts}</div>
            <div className={classes.tableCell}>{columns.score}</div>
            <div className={classes.tableCell}>{columns.overallPoints}</div>
            <div className={classes.tableCell}>{columns.pointsPercentil}</div>
        </div>
    )
}
function getTableHead(args: {
    classes: Record<'tableRow' | 'tableCell', string>
}) {
    return getTableRow({
        columns: {
            rank: '#',
            user: <></>,
            games: 'Z',
            wins3pts: 'V',
            wins2pts: 'Vp',
            loss1pt: 'Pp',
            loss0pts: 'P',
            overallPoints: 'B',
            score: 'Skore',
            pointsPercentil: 'Bp'
        },
        classes: args.classes
    })
}
function getTableBodyRow(args: {
    rowModel: StatisticViewModelType
    classes: Record<'tableRow' | 'tableCell' | 'cellEmblem', string>
}) {
    const {
        rowModel,
        classes
    } = args

    return getTableRow({
        columns: {
            ...rowModel,
            user: <>
                {getEmblemByType(rowModel.user.emblem)({ className: classes.cellEmblem })}
                {rowModel.user.nickname}
            </>,
            pointsPercentil:`${rowModel.pointsPercentil.toFixed(2)}`,
            score: `${rowModel.goalsScored}:${rowModel.goalsObtained}`
        },
        classes
    })
}

export default function LeagueRankMobileView(props: LeagueRankViewProps) {
    const classes = useStyles()
    const [playerStatistics, setPlayerStatistics] = React.useState<StatisticViewModelType[]>([])

    React.useEffect(() => {
        async function loadData() {
            const data = await statisticsService.getAllStatistics()
            setPlayerStatistics((oldData) => [...data])
        }
        loadData()
    }, [])

    return (
        <MobileSiteMenu>
            <div className={classes.table}>
                {getTableHead({
                    classes
                })}
                {playerStatistics.map((playerStatistic) => {
                    return getTableBodyRow({
                        rowModel: playerStatistic,
                        classes
                    })
                })}
            </div>
        </MobileSiteMenu>
    )
}