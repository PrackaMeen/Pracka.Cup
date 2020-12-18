import React from "react"
import { Route } from "react-router-dom"
const UserStatsView = React.lazy(() => import("../views/classic/user-stats-view"))
const UserStatsMobileView = React.lazy(() => import("../views/mobile/user-stats-mobile-view"))

export const index = '/user-stats'
export const userStatsRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<UserStatsMobileView />)
            : (<UserStatsView />)}
    </Route>
)