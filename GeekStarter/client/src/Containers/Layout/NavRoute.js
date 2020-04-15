import {Route} from "react-router-dom";
import AppBar from "../AppBar/AppBar";
import Drawer from "../Drawer/Drawer";
import React from "react";
import {useSelector} from "react-redux";
import * as moment from "moment";

const NavRoute = ({exact, path, component: Component}) => {

    const isLoggedIn = useSelector(state => {
        const dateNow = moment().utc();
        const momentTokenExpiration = moment.unix(state.auth.tokenExpiration ?? undefined).utc();
        return !!(dateNow.isBefore(momentTokenExpiration));
    });

    return (
        <Route exact={exact} path={path} render={(props) => (
            <div style={{display: 'flex'}}>
                <AppBar/>
                {isLoggedIn ? <Drawer/> : null}
                <Component {...props}/>
            </div>
        )}/>
    );
};

export default NavRoute;