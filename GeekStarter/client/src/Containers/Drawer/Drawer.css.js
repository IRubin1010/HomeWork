import {makeStyles} from "@material-ui/core/styles";

const drawerWidth = 240;

const useStyles = makeStyles(theme => ({
    drawer: {
        width: drawerWidth,
        flexShrink: 0,
        whiteSpace: "nowrap",
        overflow: 'hidden'
    },
    drawerOpen: {
        overflow: 'hidden',
        width: drawerWidth,
        transition: theme.transitions.create("width", {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen
        })
    },
    drawerClose: {
        transition: theme.transitions.create("width", {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen
        }),
        overflow: 'hidden',
        width: theme.spacing(7) + 1,
        [theme.breakpoints.up("sm")]: {
            width: theme.spacing(9) + 1
        }
    },
    drawerPaper: {
        width: drawerWidth
    },
    title: {
        flexGrow: 1,
        color: theme.palette.primary.main,
        fontWeight: 'bolder',
        fontFamily: "Baloo",
        fontSize: "1.7rem",
    },
    toolbar: {
        minHeight: 52,
        textAlign: 'center',
        [theme.breakpoints.up("sm")]: {
            height: 64,
        }
    }
}));

export default useStyles;