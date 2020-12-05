import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonEmblemProps } from '../types'
import bostonBruinsEmblemSvg from './boston-bruins-emblem.svg'

export default function BostonBruinsEmblem(props: CommonEmblemProps) {
    return (
        <SvgContainer
            src={bostonBruinsEmblemSvg}
            style={props.style}
            className={props.className}
        />
    )
}