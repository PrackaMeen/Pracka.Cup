import React from "react"
import { Route } from "react-router-dom"
const LeagueRankView = React.lazy(() => import("../views/classic/league-rank-view"))
const LeagueRankMobileView = React.lazy(() => import("../views/mobile/league-rank-mobile-view"))

export const index = '/league-rank'
export const leagueRanksRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<LeagueRankMobileView />)
            : (<LeagueRankView />)}
    </Route>
)