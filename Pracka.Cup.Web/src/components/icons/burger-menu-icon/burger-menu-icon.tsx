import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonIconProps } from '../types'
import dashIconSvg from './burger-menu-icon.svg'

export default function BurgerMenuIcon(props: CommonIconProps) {
    return (
        <SvgContainer src={dashIconSvg} style={props} />
    )
}