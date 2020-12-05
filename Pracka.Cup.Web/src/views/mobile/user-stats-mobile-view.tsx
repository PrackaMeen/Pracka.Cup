import React from "react"
import { useParams } from "react-router-dom"
import { UserStatsViewProps } from "../types"
import prackaCupDetial from "../svg/pracka-cup-detail.svg"
import MobileSiteMenu from "../../components/mobile-site-menu/mobile-site-menu"

export default function UserStatsMobileView(props: UserStatsViewProps) {
    const params = useParams() as Record<string, string | number>
    if (Object.keys(params).length > 0) {
        return (
            <>
                <img src={prackaCupDetial} alt="logo" />
                Mobile - User stats view
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
            <img src={prackaCupDetial} alt="logo" />
        </MobileSiteMenu>
    )
}