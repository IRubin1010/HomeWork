import * as actionTypes from '../Actions/ActionTypes'
import updateObject from "../../Utils/Object";

const initialState = {
    error: null,
    loading: false
};

const start = (state, action) => {
    return updateObject(state, { error: null, loading: true });
};

const success = (state, action) => {
    return updateObject(state, {
        error: null,
        loading: false
    });
};

const fail = (state, action) => {
    return updateObject(state, {
        error: action.error,
        loading: false
    });
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.SIGNUP_START: return start(state, action);
        case actionTypes.SIGNUP_SUCCESS: return success(state, action);
        case actionTypes.SIGNUP_FAIL: return fail(state, action);

        default:
            return state;
    }
};

export default reducer;