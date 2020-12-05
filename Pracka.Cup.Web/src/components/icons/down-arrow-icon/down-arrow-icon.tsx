import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import downArrowSvg from './down-arrow-icon.svg'

export default function DownArrowIcon(props: CommonIconProps) {
    return (
        <SvgContainer src={downArrowSvg} style={props} />
    )
}