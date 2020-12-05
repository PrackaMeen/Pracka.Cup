import { combineReducers } from 'redux'
import indexReducer from './reducer'

const rootReducer = combineReducers({
    index: indexReducer
})

export default rootReducer