import * as actions from './Actions'
import * as actionTypes from './ActionTypes'
import {signUpApi} from '../../Api/Auth'

const signUp = (user, callback) => {
    return async dispatch => {
        dispatch(actions.start(actionTypes.SIGNUP_START));
        try{
            let res = await signUpApi(user);
            if(res){
                dispatch(actions.success(actionTypes.SIGNUP_SUCCESS))
            }
            else{
                dispatch(actions.fail(actionTypes.SIGNUP_FAIL, "unknown error"))
            }
        }catch (err) {
            dispatch(actions.fail(actionTypes.SIGNUP_FAIL, err.response.data))
        }

    }
};

export default signUp;