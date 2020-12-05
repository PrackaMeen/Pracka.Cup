import React from "react"
import { Route } from "react-router-dom"
import NewGameView from "../views/classic/new-game-view"
import NewGameMobileView from "../views/mobile/new-game-mobile-view"

export const index = '/organize-game'
export const organizeGameRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<NewGameMobileView />)
            : (<NewGameView />)}
    </Route>
)