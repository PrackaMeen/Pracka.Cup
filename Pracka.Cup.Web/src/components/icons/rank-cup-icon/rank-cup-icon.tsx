import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import upArrowSvg from './rank-cup-icon.svg'

export default function RankCupIcon(props: CommonIconProps) {
    return (
        <SvgContainer {...props} src={upArrowSvg} />
    )
}