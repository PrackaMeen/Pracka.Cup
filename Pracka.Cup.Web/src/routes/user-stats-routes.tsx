import React from "react"
import { Route } from "react-router-dom"
import UserStatsView from "../views/classic/user-stats-view"
import UserStatsMobileView from "../views/mobile/user-stats-mobile-view"

export const index = '/user-stats'
export const userStatsRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<UserStatsMobileView />)
            : (<UserStatsView />)}
    </Route>
)