import React from "react"
import { useParams } from "react-router-dom"
import { UserStatsViewProps } from "../types"
import prackaCupDetial from "../svg/pracka-cup-detail.svg"

export default function UserStatsView(props: UserStatsViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupDetial} alt="logo" />
                User stats view
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
            <img src={prackaCupDetial} alt="logo" />
            User stats view
        </>
    )
}