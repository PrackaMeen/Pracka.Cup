import React from "react"
import { useParams } from "react-router-dom"
import { HistoryViewProps } from "../types"
import prackaCupHistory from "../svg/pracka-cup-history.svg"

export default function HistoryView(props: HistoryViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupHistory} alt="logo" />
                History view
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
            <img src={prackaCupHistory} alt="logo" />
            History view
        </>
    )
}