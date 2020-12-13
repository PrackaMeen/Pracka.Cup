import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import firstRankCupSvg from './first-rank-cup-icon.svg'

export default function FirstRankCupIcon(props: CommonIconProps) {
    return (
        <SvgContainer
            {...props}
            src={firstRankCupSvg}
        />
    )
}