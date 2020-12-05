import { INCREASE_INDEX, DECREASE_INDEX, IndexActionTypes } from "../actions/action"

const initialState = { index: 0 };

const indexReducer = (state = initialState, action: IndexActionTypes) => {
    switch (action.type) {
        case DECREASE_INDEX: {
            return {
                ...state,
                index: state.index - 1
            };
        }
        case INCREASE_INDEX: {
            return {
                ...state,
                index: state.index + 1
            };
        }
        default: {
            return state;
        }
    }
};

export default indexReducer;