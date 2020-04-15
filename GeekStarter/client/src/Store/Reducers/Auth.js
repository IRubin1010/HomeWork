import * as actionTypes from '../Actions/ActionTypes'
import updateObject from "../../Utils/Object";
import * as moment from "moment";


const initialState = {
    user: null,
    error: null,
    loading: false,
    tokenExpiration: null,
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.LOGIN_START:
            return updateObject(state, {
                error: null,
                loading: true
            });
        case actionTypes.LOGIN_SUCCESS:
            return updateObject(state, {
                user: action.user,
                error: null,
                loading: false,
            });
        case actionTypes.LOGIN_FAIL:
            return updateObject(state, {
                error: action.error,
                loading: false
            });
        case actionTypes.SET_TOKEN:
            return updateObject(state, {
                tokenExpiration: action.tokenExpiration
            });
        case actionTypes.LOGOUT_START:
            return updateObject(state, {
                error: null,
                loading: true
            });
        case actionTypes.LOGOUT_SUCCESS:
            return updateObject(state, {
                user: null,
                error: null,
                loading: false,
                tokenExpiration: moment().unix()
            });
        case actionTypes.LOGOUT_FAIL:
            return updateObject(state, {
                error: action.error,
                loading: false,
            });

        default:
            return state;
    }
};

export default reducer;