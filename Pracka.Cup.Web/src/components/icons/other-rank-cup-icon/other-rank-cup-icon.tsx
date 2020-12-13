import { makeStyles } from '@material-ui/core'
import clsx from 'clsx'
import React from 'react'
import { CommonIconProps } from '../types'
import otherRankCupSvg from './other-rank-cup-icon.svg'

const useStyles = makeStyles(() => {
    return {
        svgBackground: {
            width: '100%',
            backgroundImage: `url(${otherRankCupSvg})`,
            backgroundSize: 'cover',
            '& div': {
                fontSize: '2em',
                top: '24%',
                position: 'relative'
            }
        }
    }
})
export default function OtherRankCupIcon(props: CommonIconProps & {
    rank: number
}) {
    const innerClasses = useStyles()

    return (
        <div
            {...props}
            className={clsx(props.className, innerClasses.svgBackground)}
        >
            <div>
                {props.rank}
            </div>
        </div>
    )
}