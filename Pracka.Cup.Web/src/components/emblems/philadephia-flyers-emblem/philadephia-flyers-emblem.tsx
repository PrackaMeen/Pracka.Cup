import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonEmblemProps } from '../types'
import philladephiaFliersEmblemSvg from './philadephia-flyers-emblem.svg'

export default function PhiladelphiaFlyersEmblem(props: CommonEmblemProps) {
    return (
        <SvgContainer
            src={philladephiaFliersEmblemSvg}
            style={props.style}
            className={props.className}
        />
    )
}