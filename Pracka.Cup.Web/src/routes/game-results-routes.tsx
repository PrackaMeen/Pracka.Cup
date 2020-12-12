import React from "react"
import { Route } from "react-router-dom"
import GameResultsView from "../views/classic/game-results-view"
import GameResultsMobileView from "../views/mobile/game-results-mobile-view"

export const index = `/game/:gameId/results`
export function getGameResultsRoute(args: { gameId: number | string }) {
    return index.replace(':gameId', `${args.gameId}`)
}
export const gameResultsRoute = (isMobileDevice: boolean) => (
    <Route path={index} exact={true}>
        {isMobileDevice
            ? (<GameResultsMobileView />)
            : (<GameResultsView />)}
    </Route>
)