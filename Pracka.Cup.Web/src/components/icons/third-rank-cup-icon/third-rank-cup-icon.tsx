import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import thirdRankCupSvg from './third-rank-cup-icon.svg'

export default function ThirdRankCupIcon(props: CommonIconProps) {
    return (
        <SvgContainer
            {...props}
            src={thirdRankCupSvg}
        />
    )
}