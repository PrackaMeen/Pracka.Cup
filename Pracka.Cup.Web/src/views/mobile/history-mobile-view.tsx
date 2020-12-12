import React from "react"
import { HistoryViewProps } from "../types"
import { getEmblemByType } from "../../components/emblems/helpers"
import { PossibleEmblems } from "../../components/emblems/types"
import { HistoryViewModelRowType, HistoryViewModelType } from "../../models"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import * as historiesService from '../../services/histories-service'

const leftIconStyle: React.CSSProperties = {
    height: '4em',
    position: 'relative',
    left: '5.5%'
}
const rightIconStyle: React.CSSProperties = {
    height: '4em',
    position: 'relative',
    right: '5.5%'
}
const scoreStyles: React.CSSProperties = {
    fontSize: '3em',
    paddingTop: '0.15em',
    width: '70%'
}
const dateListItemStyles: React.CSSProperties = {
    fontSize: '1.5em',
    position: 'relative',
    left: '3%',
    display: 'flex',
    textDecoration: 'underline',
    fontWeight: 600,
    padding: '0 0 0.25em 0'
}
const historyListItemStyles: React.CSSProperties = {
    display: 'flex',
    justifyContent: 'space-around'
}

const LeftIcon = (props: { iconType: PossibleEmblems }) => {
    return getEmblemByType(props.iconType)({ style: leftIconStyle })
}
const RightIcon = (props: { iconType: PossibleEmblems }) => {
    return getEmblemByType(props.iconType)({ style: rightIconStyle })
}
const Score = (props: { score: string }) => {
    return (
        <span style={scoreStyles}>
            {props.score}
        </span>
    )
}
const DateListItem = (props: { label: string }) => {
    const {
        label
    } = props

    return (
        <li style={dateListItemStyles}>
            {label}
        </li>
    )
}
function toHistoryListItem({ key, leftTeam, score, rightTeam }: HistoryViewModelRowType) {
    return (
        <li
            key={`${key}`}
            style={historyListItemStyles}
        >
            <LeftIcon iconType={leftTeam} />
            <Score score={score} />
            <RightIcon iconType={rightTeam} />
        </li>
    )
}

function getDateString(date: Date) {
    const currentTime = Date.now()
    const milisecondsBetweenNowAndDate = currentTime - Date.parse(date.toISOString())

    const daysInWeek = 7
    const hoursInDay = 24
    const minutesInHour = 60
    const secondsInMinute = 60
    const milisecondsInSecond = 1000

    const weekInMiliseconds = daysInWeek
        * hoursInDay
        * minutesInHour
        * secondsInMinute
        * milisecondsInSecond

    if (milisecondsBetweenNowAndDate < weekInMiliseconds) {
        const daysInMiliseconds = weekInMiliseconds / daysInWeek
        const numberOfDays = Math.floor(milisecondsBetweenNowAndDate / daysInMiliseconds)
        if (numberOfDays > 0) {
            return numberOfDays === 1
                ? `${numberOfDays} day ago:`
                : `${numberOfDays} days ago:`
        }

        const hoursInMiliseconds = daysInMiliseconds / hoursInDay
        const numberOfHours = Math.floor(milisecondsBetweenNowAndDate / hoursInMiliseconds)
        if (numberOfHours > 0) {
            return numberOfHours === 1
                ? `${numberOfHours} hour ago:`
                : `${numberOfHours} hours ago:`
        }

        const minutesInMiliseconds = hoursInMiliseconds / minutesInHour
        const numberOfMinutes = Math.floor(milisecondsBetweenNowAndDate / minutesInMiliseconds)
        if (numberOfMinutes > 0) {
            return numberOfMinutes === 1
                ? `${numberOfMinutes} minute ago:`
                : `${numberOfMinutes} minutes ago:`
        }

        const secondsInMiliseconds = minutesInMiliseconds / secondsInMinute
        const numberOfSeconds = Math.floor(milisecondsBetweenNowAndDate / secondsInMiliseconds)
        if (numberOfSeconds > 0) {
            return numberOfSeconds === 1
                ? `${numberOfSeconds} second ago:`
                : `${numberOfSeconds} seconds ago:`
        }

        return `${milisecondsBetweenNowAndDate} miliseconds ago:`
    } else {
        return `${date.toLocaleDateString()}:`
    }
}

export default function HistoryMobileView(props: HistoryViewProps) {
    const [historyItems, setHistoryItems] = React.useState<HistoryViewModelType[]>([])

    React.useEffect(() => {
        const fetchData = async () => {
            let newHistoryItems = await historiesService.getFullHistory()
            setHistoryItems(newHistoryItems.reverse())
        }

        fetchData()
    }, [])

    return (
        <MobileSiteMenu>
            <ul style={{ padding: '1em 0em' }}>
                {historyItems.map(({ date, rows }, index) => {
                    return (
                        <React.Fragment key={date.toISOString() + index}>
                            <DateListItem
                                key={getDateString(date)}
                                label={getDateString(date)}
                            />
                            {rows.map(toHistoryListItem)}
                        </React.Fragment>
                    )
                })}
            </ul>
        </MobileSiteMenu>
    )
}