import React from "react";
import AppBar from "../AppBar/AppBar"
import {BrowserRouter as Router, Switch, Route} from "react-router-dom";

import DashBoard from "../../Components/DashBoard/DashBoard";
import Project from "../../Components/Project/Project";
import Profile from "../../Components/Profile/Profile";
import SignUp from "../../Components/SignUp/SignUp";
import ForgotPassword from "../../Components/ForgotPassword/ForgotPassword";


const layout = (props) => {
    return (
        <Router>
            <AppBar/>
            <main>
                <Switch>
                    <Route path="/projects/:projectId" component={Project}/>
                    <Route path="/profile" component={Profile}/>
                    <Route path="/signUp" component={SignUp}/>
                    <Route path="/forgotPassword" component={ForgotPassword}/>
                    <Route path="/">
                        <DashBoard/>
                    </Route>
                </Switch>
            </main>
        </Router>
    )
};

export default layout;