import React from "react"
import { Route } from "react-router-dom"
import HistoryView from "../views/classic/history-view"
import HistoryMobileView from "../views/mobile/history-mobile-view"

export const index = '/history'
export const historyRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<HistoryMobileView />)
            : (<HistoryView />)}
    </Route>
)