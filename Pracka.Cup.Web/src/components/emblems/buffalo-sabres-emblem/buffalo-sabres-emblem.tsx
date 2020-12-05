import React from 'react'
import SvgContainer from '../../svg-container'
import { CommonEmblemProps } from '../types'
import buffaloSabresEmblemSvg from './buffalo-sabres-emblem.svg'

export default function BuffaloSabresEmblem(props: CommonEmblemProps) {
    return (
        <SvgContainer
            src={buffaloSabresEmblemSvg}
            style={props.style}
            className={props.className}
        />
    )
}
