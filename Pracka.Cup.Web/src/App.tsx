import React from 'react'
import './App.css'

import { HashRouter as Router, Redirect, Switch } from 'react-router-dom'
import { index as historyIndex, historyRoute } from './routes/history-routes'
import { leagueRanksRoute } from './routes/league-rank-routes'
import { organizeGameRoute } from './routes/organize-game-routes'
import { gameResultsRoute } from './routes/game-results-routes'
import { userStatsRoute } from './routes/user-stats-routes'

function isMobileDevice() {
  const d = document,
    documentElement = d.documentElement,
    rootElement = d.getElementsByTagName('root')[0],
    windowWidth = window.innerWidth ||
      documentElement.clientWidth ||
      rootElement.clientWidth

  return windowWidth <= 568
}

function App() {
  const isMobileType = isMobileDevice()

  return (
    <div className="App">
      <React.Suspense fallback={'Loading...'}>
        <Router hashType='noslash' >
          <Switch>
            <Redirect from='/' to={historyIndex} exact={true} />
            {userStatsRoute(isMobileType)}
            {historyRoute(isMobileType)}
            {leagueRanksRoute(isMobileType)}
            {organizeGameRoute(isMobileType)}
            {gameResultsRoute(isMobileType)}
          </Switch>
        </Router>
      </React.Suspense>
    </div>
  );
}

export default App;
