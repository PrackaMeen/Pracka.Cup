import React from "react"
import { GameResultsViewProps } from "../types"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"
import { makeStyles } from "@material-ui/core"
import clsx from "clsx"

function GameBox(props: { value: number, className?: string }) {
    const { value, className } = props
    return (
        <div className={className}>{value}</div>
    )
}

const useStyles = makeStyles(() => {
    return {
        box: {

        },
        winner: {
            color: 'green'
        },
        loser: {
            color: 'red'
        }
    }
})

type GameResultType = 'CLASSIC' | 'OVERTIME' | 'SHOOTOUT'
export default function GameResultsMobileView(props: GameResultsViewProps) {
    const classes = useStyles()

    function getBoxClass(args: {
        resultType: GameResultType,
        currentType: GameResultType,
        className: string
    }) {
        return args.resultType === args.currentType
            ? clsx(classes.box, args.className)
            : classes.box
    }

    const currentGameType: GameResultType = 'CLASSIC'

    return (
        <MobileSiteMenu>
            <div style={{ display: 'grid' }}>
                <div style={{ display: 'inline-flex' }}>
                    <div>BOSTON</div>
                    <div style={{ display: 'grid' }}>
                        <div>Vyhra</div>
                        <div>Marek</div>
                    </div>

                </div>
                <div style={{ display: 'inline-flex' }}>
                    <div style={{ display: 'grid' }}>
                        <div style={{ display: 'inline-flex' }}>
                            <div>Poradie</div>
                            <div>Pohar</div>
                            <div>Sipka</div>
                        </div>
                        <div style={{ display: 'inline-flex' }}>
                            <div>Bilancia:</div>
                        </div>
                        <div style={{ display: 'inline-flex' }}>
                            <GameBox
                                value={52}
                                className={getBoxClass({
                                    className: classes.winner,
                                    resultType: 'CLASSIC',
                                    currentType: currentGameType
                                })}
                            />
                            <div className={classes.box} >/</div>
                            <GameBox
                                value={10}
                                className={getBoxClass({
                                    className: classes.winner,
                                    resultType: 'OVERTIME',
                                    currentType: currentGameType
                                })}
                            />
                            <div className={classes.box} >/</div>
                            <GameBox
                                value={2}
                                className={getBoxClass({
                                    className: classes.winner,
                                    resultType: 'SHOOTOUT',
                                    currentType: currentGameType
                                })}
                            />
                        </div>
                    </div>

                </div>
            </div>
        </MobileSiteMenu>
    )
}