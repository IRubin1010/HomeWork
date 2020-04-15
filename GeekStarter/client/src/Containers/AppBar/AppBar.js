import React, {Fragment, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {useHistory, useLocation} from "react-router-dom";
import * as moment from 'moment';

import {AppBar as MaterialUIAppBar} from "@material-ui/core";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import InputBase from '@material-ui/core/InputBase';
import Button from "@material-ui/core/Button";
import SearchIcon from '@material-ui/icons/Search';
import CloseIcon from '@material-ui/icons/Close';
import Menu from "@material-ui/core/Menu";
import MenuItem from "@material-ui/core/MenuItem";
import MoreIcon from "@material-ui/icons/MoreVert";
import Avatar from "@material-ui/core/Avatar";
import KeyboardArrowDownIcon from '@material-ui/icons/KeyboardArrowDown';
import MenuIcon from "@material-ui/icons/Menu";

import useStyles from "./AppBar.css";
import Auth from "../../Store/Actions/Auth";
import Grid from "@material-ui/core/Grid";
import InputLabel from "@material-ui/core/InputLabel";
import Drawer from "../Drawer/Drawer";
import DashBoard from '../../Components/DashBoard/DashBoard'
import Layout from "../../Store/Actions/Layout";

const AppBar = (props) => {

    // state
    const [isSearch, setIsSearch] = useState(false);
    const [menuAnchorEl, setMenuAnchorEl] = React.useState(null);
    const isMenuOpen = Boolean(menuAnchorEl);
    const isLoggedIn = useSelector(state => {
        const dateNow = moment().utc();
        const momentTokenExpiration = moment.unix(state.auth.tokenExpiration ?? undefined).utc();
        return !!(dateNow.isBefore(momentTokenExpiration));
    });
    const user = useSelector(state => state.auth.user);
    const mobileDrawerOpen = useSelector(state => state.layout.mobileDrawerOpen);

    // uses
    const classes = useStyles();
    const history = useHistory();
    const location = useLocation();
    const dispatch = useDispatch();

    const handleMenuOpen = event => {
        setMenuAnchorEl(event.currentTarget);
    };

    const handleMenuClose = () => {
        setMenuAnchorEl(null);
    };

    const login = () => {
        setMenuAnchorEl(null);
        if (location.pathname !== '/login') {
            history.push('/login')
        }
    };

    const signUp = () => {
        setMenuAnchorEl(null);
        if (location.pathname !== '/signUp') {
            history.push('/signUp')
        }
    };

    const logout = async () => {
        try {
            await dispatch(Auth.logout());
            setMenuAnchorEl(null);
        } catch (err) {
            console.log(err);
        }
    };

    const handleDrawerToggle = () => {
        dispatch(Layout.setMobileDrawer(!mobileDrawerOpen));
    };

    const menuItems = isLoggedIn ?
        <MenuItem
            className={classes.menuItem}
            onClick={logout}>
            LOG OUT
        </MenuItem>
        :
        [
            <MenuItem
                key={'first'}
                className={classes.menuItem}
                onClick={login}>
                LOG IN
            </MenuItem>,
            <MenuItem
                key={'second'}
                className={classes.menuItem}
                onClick={signUp}>
                SIGN UP
            </MenuItem>
        ];

    const menu = (
        <Menu
            anchorEl={menuAnchorEl}
            anchorOrigin={{vertical: 'bottom', horizontal: 'right'}}
            keepMounted
            transformOrigin={{vertical: 'top', horizontal: 'right'}}
            open={isMenuOpen}
            onClose={handleMenuClose}
            getContentAnchorEl={null}
        >
            {menuItems}
        </Menu>
    );

    let toolBar =
        <Toolbar className={classes.toolBar}>
            {isLoggedIn ?
                <IconButton
                    color="inherit"
                    aria-label="open drawer"
                    edge="start"
                    onClick={handleDrawerToggle}
                    className={classes.menuButton}
                >
                    <MenuIcon className={classes.menuIcon}/>
                </IconButton>
                : null
            }
            <Typography variant="h6" className={classes.title}>
                GeekStarter
            </Typography>
            <IconButton edge="end" className={classes.searchIcon} onClick={() => setIsSearch(true)}>
                <SearchIcon/>
            </IconButton>
            <div className={classes.sectionDesktop}>
                <div className={classes.separator}/>
                {!isLoggedIn ?
                    <Fragment>
                        <Button
                            color="inherit"
                            className={classes.loginButton}
                            onClick={login}>
                            Log in
                        </Button>
                        <div className={classes.loginSeparator}/>
                        <Button
                            color="inherit"
                            className={classes.loginButton}
                            onClick={signUp}>
                            Sign Up
                        </Button>
                    </Fragment>
                    :
                    <Button className={classes.profile} onClick={handleMenuOpen}>
                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <Avatar
                                    className={classes.avatar}>{`${user?.firstName} ${user?.lastName}`.initials()}</Avatar>
                            </Grid>
                            <Grid item className={classes.profileName}>
                                <InputLabel
                                    className={classes.profileNameLabel}>{`${user?.firstName.capitalize()} ${user?.lastName.capitalize()}`}</InputLabel>
                            </Grid>
                            <Grid item className={classes.profileName}>
                                <KeyboardArrowDownIcon/>
                            </Grid>
                        </Grid>
                    </Button>
                }
            </div>
            <div className={classes.sectionMobile}>
                {isLoggedIn ?
                    <Avatar
                        className={classes.avatarSmall}
                        onClick={handleMenuOpen}
                    >
                        {`${user?.firstName} ${user?.lastName}`.initials()}
                    </Avatar>
                    :
                    <IconButton className={classes.moreIcon} onClick={handleMenuOpen} color="inherit">
                        <MoreIcon/>
                    </IconButton>
                }

            </div>
            {menu}
        </Toolbar>;

    if (isSearch) {
        toolBar =
            <Toolbar>
                <SearchIcon/>
                <InputBase
                    className={classes.input}
                    placeholder="Search..."
                />
                <IconButton edge="end" className={classes.closeIcon} onClick={() => setIsSearch(false)}>
                    <CloseIcon/>
                </IconButton>
            </Toolbar>;
    }

    return (
        <div className={classes.root}>
            <MaterialUIAppBar position="fixed" className={classes.appBar}>
                {toolBar}
            </MaterialUIAppBar>
        </div>
    );
};

export default AppBar;

