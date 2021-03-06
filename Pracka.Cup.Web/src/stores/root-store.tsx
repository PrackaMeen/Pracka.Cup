import { createStore } from 'redux'
import rootReducer from '../reducers/root-reducers'

const store = createStore(rootReducer)

export default store