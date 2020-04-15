import axios from 'axios';
import store from '../Store/Store'
import Auth from "../Store/Actions/Auth";
const {dispatch} = store;

const instance = axios.create({
    baseURL: 'http://localhost:4000'
});
instance.defaults.withCredentials = true;
instance.interceptors.response.use(response => {
    if(response.data.token){
        dispatch(Auth.setToken(response.data.token));
    }

    return response;
}, error => {
    if (401 === error.response.status && window.location.pathname !== '/login') {
        window.location = '/login';
    }
    return Promise.reject(error);
});

export default instance;