import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField/TextField'
import clsx from 'clsx';
import React from 'react'

function isNegative(value: number) {
    return 0 > value
}
function isInputInvalid(value: number) {
    return true === isNegative(value)
}

const useStyles = makeStyles((theme) => ({
    scoreInput: {
        fontSize: '4em',
        width: '2em',
    }
}));

type ScoreInputClasses = 'rowSide' | 'inputAlign'
export default function ScoreInput(props: {
    label: string
    scoreValue: number
    onScoreChange: (newScore: number) => void
    classes: Record<ScoreInputClasses, string>
}) {
    const innerClasses = useStyles()
    const {
        label,
        classes,
        scoreValue,
        onScoreChange
    } = props

    return (
        <TextField
            required={true}
            error={isInputInvalid(scoreValue)}
            type={'number'}
            label={label}
            className={classes.rowSide}
            inputProps={{
                className: clsx(innerClasses.scoreInput, classes.inputAlign)
            }}
            InputLabelProps={{
                shrink: true,
            }}
            placeholder={'0'}
            size='medium'
            onChange={(event) => {
                const value = Number(event.target.value)
                onScoreChange && onScoreChange(value)
            }}
        />
    )
}