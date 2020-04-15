import rootReducer from './Reducers'
import thunk from 'redux-thunk';
import {createStore, applyMiddleware, compose} from "redux";

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const saveState = (state) => {
    try {
        const serializedState = JSON.stringify(state);
        localStorage.setItem('state', serializedState);
    } catch {
        // ignore write errors
    }
};

const loadState = () => {
    try {
        const serializedState = localStorage.getItem('state');
        if (serializedState === null) {
            return undefined;
        }
        return JSON.parse(serializedState);
    } catch (err) {
        return undefined;
    }
};

const store = createStore(rootReducer, loadState(), composeEnhancers(
    applyMiddleware(thunk)
));

store.subscribe(() => {
    saveState(store.getState());
});

export default store;