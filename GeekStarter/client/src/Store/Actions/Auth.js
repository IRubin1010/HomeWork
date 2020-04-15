import * as actions from './Actions'
import * as actionTypes from './ActionTypes'
import {loginApi, logoutApi} from '../../Api/Auth'
import jwt from 'jsonwebtoken'

const login = (email, password, callback) => {
    return async dispatch => {
        dispatch(actions.start(actionTypes.LOGIN_START));
        try{
            const res = await loginApi(email, password);
            if(res){
                const user = {
                  ...res.data,
                  token: undefined
                };
                dispatch(actions.success(actionTypes.LOGIN_SUCCESS, {user: user}));
            }
            else{
                dispatch(actions.fail(actionTypes.LOGIN_FAIL, "unknown error"))
            }
        }catch (err) {
            dispatch(actions.fail(actionTypes.LOGIN_FAIL, err.response.data))
        }

    }
};

const setToken = (token) => {
    return dispatch => {
        const decodedToken = jwt.decode(token, {complete: true});
        const tokenExpiration = decodedToken.payload.exp;
        dispatch(actions.success(actionTypes.SET_TOKEN, {
            tokenExpiration: tokenExpiration
        }));
    }
};

const logout = () => {
    return async dispatch => {
        dispatch(actions.start(actionTypes.LOGOUT_START));
        try {
            await logoutApi();
            dispatch(actions.success(actionTypes.LOGOUT_SUCCESS));
        } catch (err) {
            dispatch(actions.fail(actionTypes.LOGOUT_FAIL, err.response.data))
        }
    };
};


export default {
    login,
    logout,
    setToken
};