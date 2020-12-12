import Button from "@material-ui/core/Button/Button"
import { getEmblemByType } from "../emblems/helpers"
import { PossibleEmblems } from "../emblems/types"
import React from "react"

type WinButtonClasses = 'buttonEmblem' | 'buttonLabel'
export default function WinButton(props: {
    label: string,
    emblemType?: PossibleEmblems,
    classes: Partial<Record<WinButtonClasses, string>>
    onClick: () => void
    disabled: boolean
}) {
    const {
        label,
        emblemType,
        classes,
        onClick: handleClick,
        disabled
    } = props

    return (
        <Button
            classes={{
                label: classes?.buttonLabel
            }}
            startIcon={emblemType && getEmblemByType(emblemType)({
                className: classes?.buttonEmblem
            })}
            endIcon={emblemType && getEmblemByType(emblemType)({
                className: classes?.buttonEmblem
            })}
            onClick={handleClick}
            disabled={disabled}
        >
            <span style={{ width: '80%' }}>{label}</span>
        </Button>
    )
}