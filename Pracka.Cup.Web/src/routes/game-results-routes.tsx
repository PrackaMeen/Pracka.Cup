import React from "react"
import { Route } from "react-router-dom"
const GameResultsView = React.lazy(() => import("../views/classic/game-results-view"))
const GameResultsMobileView = React.lazy(() => import("../views/mobile/game-results-mobile-view"))

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