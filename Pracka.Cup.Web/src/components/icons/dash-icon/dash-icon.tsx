import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import dashIconSvg from './dash-icon.svg'

export default function DashIcon(props: CommonIconProps) {
    return (
        <SvgContainer {...props} src={dashIconSvg} />
    )
}