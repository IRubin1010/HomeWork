import * as actionTypes from '../Actions/ActionTypes'
import updateObject from "../../Utils/Object";

const initialState = {
    mobileDrawerOpen: false
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.SET_MOBILE_DRAWER_OPEN:
            return updateObject(state, {
                mobileDrawerOpen: true,
            });
        case actionTypes.SET_MOBILE_DRAWER_CLOSE:
            return updateObject(state, {
                mobileDrawerOpen: false,
            });
        default:
            return state;
    }
};

export default reducer;