import React, {Fragment, useState} from "react";
import {AppBar as MaterialUIAppBar} from "@material-ui/core";
import useMediaQuery from '@material-ui/core/useMediaQuery';
import {Link, useHistory} from "react-router-dom"

import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import InputBase from '@material-ui/core/InputBase';
import Button from "@material-ui/core/Button";

import MenuIcon from '@material-ui/icons/Menu';
import SearchIcon from '@material-ui/icons/Search';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import AccountCircleIcon from "@material-ui/icons/AccountCircle";

import useStyles from "./AppBar.css";
import Login from "../../Components/Login/Login";


const AppBar = (props) => {

    const [isSearchInSmallScreen, setIsSearchInSmallScreen] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [isLoginDialogOpen, setIsLoginDialogOpen] = useState(false);

    const classes = useStyles();
    const history = useHistory();

    const isSmallScreen = useMediaQuery(theme => theme.breakpoints.down('xs'));

    const signUpClick = () => {
        setIsLoginDialogOpen(false);
        history.push('/signUp')
    };

    const forgotPasswordClick = () => {
        setIsLoginDialogOpen(false);
        history.push('/forgotPassword')
    };


    let toolBarIcon = isSearchInSmallScreen ?
        (<IconButton edge="start" className={classes.arrowBackButton} onClick={() => setIsSearchInSmallScreen(false)}>
            <ArrowBackIcon/>
        </IconButton>)
        : (<IconButton edge="start" className={classes.menuButton} aria-label="menu">
            <MenuIcon/>
        </IconButton>);

    let title = isSearchInSmallScreen ? null :
        <Typography variant="h6" className={classes.title}>
            GeekStarter
        </Typography>;

    let search =
        <IconButton edge="end" onClick={() => setIsSearchInSmallScreen(true)}>
            <SearchIcon/>
        </IconButton>;

    if (!isSmallScreen || isSearchInSmallScreen) {
        search =
            <div className={classes.search}>
                <div className={classes.searchIcon}>
                    <SearchIcon/>
                </div>
                <InputBase
                    placeholder="Search…"
                    classes={{
                        root: classes.inputRoot,
                        input: classes.inputInput,
                    }}
                    inputProps={{'aria-label': 'search'}}
                />
            </div>
    }

    let accountInfo = isSmallScreen || window.location.pathname.startsWith('/signUp') ? null
        : isLoggedIn ?
            <Link to={`profile`}>
                <IconButton
                    className={classes.accountInfoButton}
                    edge="end"
                    aria-label="account of current user"
                    aria-haspopup="true"
                    color="inherit">
                    <AccountCircleIcon style={{width: '2.3rem', height: '2.3rem'}}/>
                </IconButton>
            </Link>
            : <Fragment>
                <Button
                    color="inherit"
                    className={classes.accountInfoButton}
                    onClick={() => setIsLoginDialogOpen(true)}>
                    Login
                </Button>

            </Fragment>;


    return (
        <div className={classes.root}>
            <MaterialUIAppBar position="static" color="primary">
                <Toolbar>
                    {toolBarIcon}
                    {title}
                    {search}
                    {accountInfo}
                    <Login open={isLoginDialogOpen} onClose={() => setIsLoginDialogOpen(false)}
                           onSignUpClick={signUpClick} onForgotPasswordClick={forgotPasswordClick}/> {/*TODO move login into login button*/}
                </Toolbar>
            </MaterialUIAppBar>
        </div>
    );
};

export default AppBar;

