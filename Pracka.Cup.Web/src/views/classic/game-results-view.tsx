import React from "react"
import { useParams } from "react-router-dom"
import { GameResultsViewProps } from "../types"
import prackaCupEndGame from "../svg/pracka-cup-end-game.svg"

export default function GameResultsView(props: GameResultsViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupEndGame} alt="logo" />
                Game results view
                {Object.keys(params).map((param) => {
                    return (
                        <React.Fragment key={param}>
                            {`${param}: ${params[param]}`}
                        </React.Fragment>
                    )
                })}
            </>
        )
    }

    return (
        <>
            <img src={prackaCupEndGame} alt="logo" />
            Game results view
        </>
    )
}