import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import secondRankCupSvg from './second-rank-cup-icon.svg'

export default function SecondRankCupIcon(props: CommonIconProps) {
    return (
        <SvgContainer
            {...props}
            src={secondRankCupSvg}
        />
    )
}