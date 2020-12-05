import React from "react"
import { Route } from "react-router-dom"
import LeagueRankView from "../views/classic/league-rank-view"
import LeagueRankMobileView from "../views/mobile/league-rank-mobile-view"

export const index = '/league-rank'
export const leagueRanksRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<LeagueRankMobileView />)
            : (<LeagueRankView />)}
    </Route>
)