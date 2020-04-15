import signUp from './SignUp'
import auth from './Auth'
import layout from './Layout'
import {combineReducers} from 'redux'

const rootReducer = combineReducers({
    signUp,
    auth,
    layout
});

export default rootReducer