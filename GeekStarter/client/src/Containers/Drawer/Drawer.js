import React, {Fragment, useState} from "react";
import {Drawer as MaterialUIDrawer} from "@material-ui/core";
import useStyles from "./Drawer.css";
import clsx from "clsx";

import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import Divider from "@material-ui/core/Divider";
import Toolbar from "@material-ui/core/Toolbar";

import DashboardIcon from '@material-ui/icons/Dashboard';
import ForumIcon from '@material-ui/icons/Forum';
import CategoryIcon from '@material-ui/icons/Category';
import BubbleChartIcon from '@material-ui/icons/BubbleChart';
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
//import BusinessIcon from '@material-ui/icons/Business';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import PaymentIcon from '@material-ui/icons/Payment';
import InfoIcon from '@material-ui/icons/Info';
import HelpIcon from '@material-ui/icons/Help';
import SettingsIcon from '@material-ui/icons/Settings';
import Hidden from "@material-ui/core/Hidden";
import {useDispatch, useSelector} from "react-redux";
import Layout from "../../Store/Actions/Layout";
import Typography from "@material-ui/core/Typography";


const Drawer = (props) => {

    const classes = useStyles();

    const [open, setOpen] = useState(false);

    const mobileDrawerOpen = useSelector(state => state.layout.mobileDrawerOpen);
    const dispatch = useDispatch();

    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    const onMouseEnter = () => {
        handleDrawerOpen();
    };

    const onMouseLeave = () => {
        handleDrawerClose();
    };

    const handleDrawerToggle = () => {
        dispatch(Layout.setMobileDrawer(!mobileDrawerOpen));
    };

    const drawerItems =
        <Fragment>
            <List>
                <ListItem button>
                    <ListItemIcon>
                        <DashboardIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Dashboard'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <AccountBalanceIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Companies'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <ForumIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Chat'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <CategoryIcon/>
                    </ListItemIcon>
                    <ListItemText primary='My Campaigns'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <BubbleChartIcon/>
                    </ListItemIcon>
                    <ListItemText primary='My Investments'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <InfoIcon/>
                    </ListItemIcon>
                    <ListItemText primary='About Us'/>
                </ListItem>
            </List>
            <List style={{position: 'absolute', bottom: 0, width: 240}}>
                <ListItem button>
                    <ListItemIcon>
                        <AccountCircleIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Profile'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <PaymentIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Billing'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <SettingsIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Settings'/>
                </ListItem>
                <ListItem button>
                    <ListItemIcon>
                        <HelpIcon/>
                    </ListItemIcon>
                    <ListItemText primary='Help'/>
                </ListItem>
            </List>
        </Fragment>;

    return (
        <Fragment>
            <Hidden smDown>
                <MaterialUIDrawer
                    variant="permanent"
                    className={clsx(classes.drawer, {
                        [classes.drawerOpen]: open,
                        [classes.drawerClose]: !open
                    })}
                    classes={{
                        paper: clsx({
                            [classes.drawerOpen]: open,
                            [classes.drawerClose]: !open
                        })
                    }}
                    onMouseEnter={onMouseEnter}
                    onMouseLeave={onMouseLeave}
                >
                    <Toolbar/>
                    {drawerItems}
                </MaterialUIDrawer>
            </Hidden>
            <Hidden mdUp>
                <MaterialUIDrawer
                    variant="temporary"
                    anchor="left"
                    open={mobileDrawerOpen}
                    onClose={handleDrawerToggle}
                    classes={{
                        paper: classes.drawerPaper
                    }}
                    ModalProps={{
                        keepMounted: true
                    }}
                >
                    <Toolbar className={classes.toolbar}>
                        <Hidden smUp>
                            <Typography variant="h6" className={classes.title}>
                                GeekStarter
                            </Typography>
                        </Hidden>
                    </Toolbar>
                    <Divider/>
                    {drawerItems}
                </MaterialUIDrawer>
            </Hidden>
        </Fragment>
    )
};

export default Drawer;