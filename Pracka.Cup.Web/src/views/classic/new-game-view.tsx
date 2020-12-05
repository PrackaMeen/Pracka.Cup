import React from "react"
import { useParams } from "react-router-dom"
import { NewGameViewProps } from "../types"
import prackaCupNewGame from "../svg/pracka-cup-new-game.svg"

export default function NewGameView(props: NewGameViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupNewGame} alt="logo" />
                New game view
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
            <img src={prackaCupNewGame} alt="logo" />
            New game view
        </>
    )
}