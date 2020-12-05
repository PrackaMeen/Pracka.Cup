import React from "react"
import { useParams } from "react-router-dom"
import { LeagueRankViewProps } from "../types"
import prackaCupRank from "../svg/pracka-cup-rank.svg"

export default function LeagueRankView(props: LeagueRankViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupRank} alt="logo" />
                League rank view
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
            <img src={prackaCupRank} alt="logo" />
            League rank view
        </>
    )
}