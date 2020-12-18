import React from "react"
import { Route } from "react-router-dom"
const HistoryView = React.lazy(() => import("../views/classic/history-view"))
const HistoryMobileView = React.lazy(() => import("../views/mobile/history-mobile-view"))

export const index = '/history'
export const historyRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<HistoryMobileView />)
            : (<HistoryView />)}
    </Route>
)