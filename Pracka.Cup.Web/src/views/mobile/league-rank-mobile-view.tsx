import React from "react"
import { useParams } from "react-router-dom"
import { LeagueRankViewProps } from "../types"
import prackaCupRank from "../svg/pracka-cup-rank.svg"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"

export default function LeagueRankMobileView(props: LeagueRankViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupRank} alt="logo" />
                Mobile - League rank view
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
        <MobileSiteMenu>
            <img src={prackaCupRank} alt="logo" />
        </MobileSiteMenu>
    )
}