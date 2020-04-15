import * as actionTypes from './ActionTypes'
import * as actions from './Actions'

const setMobileDrawer = (state) => {
    return  dispatch => {
        if(state){
            return dispatch(actions.success(actionTypes.SET_MOBILE_DRAWER_OPEN))
        }
        return dispatch(actions.success(actionTypes.SET_MOBILE_DRAWER_CLOSE))
    };
};

export default {
    setMobileDrawer
};