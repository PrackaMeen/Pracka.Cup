import React from "react"
import { Route } from "react-router-dom"
const NewGameView = React.lazy(() => import("../views/classic/new-game-view"))
const NewGameMobileView = React.lazy(() => import("../views/mobile/new-game-mobile-view"))

export const index = '/organize-game'
export const organizeGameRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<NewGameMobileView />)
            : (<NewGameView />)}
    </Route>
)