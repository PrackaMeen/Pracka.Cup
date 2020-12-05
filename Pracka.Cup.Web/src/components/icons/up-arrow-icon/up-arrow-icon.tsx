import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import upArrowSvg from './up-arrow-icon.svg'

export default function UpArrowIcon(props: CommonIconProps) {
    return (
        <SvgContainer src={upArrowSvg} style={props} />
    )
}