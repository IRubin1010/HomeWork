import React from "react";
import AppBar from "../AppBar/AppBar"
import {BrowserRouter as Router, Switch, Route} from "react-router-dom";

import DashBoard from "../../Components/DashBoard/DashBoard";
import Project from "../../Components/Project/Project";
import Profile from "../../Components/Profile/Profile";
import SignUp from "../SignUp/SignUp";
import ForgotPassword from "../../Components/ForgotPassword/ForgotPassword";
import Login from "../Login/Login";
import Drawer from "../Drawer/Drawer";
import NavRoute from "./NavRoute";

const A = ()=>{
    return(
        <div style={{display: 'flex'}}>
        <AppBar/>
        <DashBoard/>
        </div>
    )
};

const AppRoute = ({exact, path, component: Component}) => (
    <Route exact={exact} path={path} render={(props) => (
        <div style={{display: 'flex'}}>
            <AppBar/>
            <Component style={{marginTop: 150}} {...props}/>
        </div>
    )}/>
);

const Layout = (props) => {
    return (
        <Router>
            <main>
                <Switch>
                    <NavRoute path="/projects/:projectId" component={Project}/>
                    <Route path="/profile" component={Profile}/>
                    <AppRoute path="/signUp" component={SignUp}/>
                    <AppRoute path="/login" component={Login}/>
                    <Route path="/forgotPassword" component={ForgotPassword}/>
                    <NavRoute component={DashBoard} path="/"/>
                </Switch>
            </main>
        </Router>
    )
};

export default Layout;