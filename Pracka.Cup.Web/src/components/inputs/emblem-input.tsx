import { getEmblemByType } from "../emblems/helpers"
import { PossibleEmblems } from "../emblems/types"
import React from 'react'

type EmblemInputClasses = 'emblem'
export default function EmblemInput(props: {
    classes: Partial<Record<EmblemInputClasses, string>>
    emblemType: PossibleEmblems
    onClick(): void
    onDoubleClick(): void
}) {
    const {
        classes,
        emblemType,
        onClick,
        onDoubleClick
    } = props

    let timeout: any = null
    return (
        <span
            onClick={function (event: React.MouseEvent<HTMLSpanElement, MouseEvent>) {
                if (!timeout) {
                    timeout = setTimeout(function () {
                        onClick()
                        timeout = null
                    }, 250)
                }
                else {
                    onDoubleClick()
                    clearTimeout(timeout)
                    timeout = null
                }
            }}
        >
            {getEmblemByType(emblemType)({
                className: classes?.emblem
            })}
        </span>
    )
}
