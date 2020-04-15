import {makeStyles} from "@material-ui/core/styles";

const useStyles = makeStyles(theme => ({
    root: {
        display: "flex",
    },
    appBar: {
        zIndex: theme.zIndex.drawer + 1,
        transition: theme.transitions.create(["width", "margin"], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen
        }),
        backgroundColor: 'white',
        [theme.breakpoints.down('xs')]: {
            height: '52px'
        }
    },
    toolBar: {
        [theme.breakpoints.up('sm')]: {
            paddingRight: theme.spacing(0),
        }
    },
    title: {
        flexGrow: 1,
        color: theme.palette.primary.main,
        fontWeight: 'bolder',
        fontFamily: "Baloo",
        fontSize: "1.7rem",
        [theme.breakpoints.up('sm')]: {
            fontSize: "2.5rem",
            marginLeft: theme.spacing(2)
        }
    },
    searchIcon: {
        marginRight: theme.spacing(0),
        "&:hover": {
            color: theme.palette.primary.main,
            backgroundColor: 'inherit'
        },
        [theme.breakpoints.up('sm')]: {
            marginRight: theme.spacing(1),
        },
    },
    moreIcon: {
        color: theme.palette.primary.main,
        paddingLeft: theme.spacing(0),
        paddingRight: theme.spacing(0),
        "&:hover": {
            backgroundColor: 'inherit'
        }
    },
    input: {
        marginLeft: theme.spacing(2),
        flexGrow: 1,
    },
    closeIcon: {
        "&:hover": {
            color: theme.palette.primary.main,
            backgroundColor: 'inherit'
        }
    },
    loginButton: {
        margin: theme.spacing(0, 1, 0, 1),
        color: 'black',
        "&:hover": {
            color: theme.palette.primary.main,
            backgroundColor: 'inherit'
        },
    },
    separator: {
        backgroundColor: 'rgba(0, 0, 0, 0.12)',
        width: '1px',
        height: '64px',
    },
    loginSeparator: {
        backgroundColor: 'rgba(0, 0, 0, 0.12)',
        width: '0.5px',
        height: '30px',
        marginTop: 17,
    },
    sectionDesktop: {
        display: 'none',
        [theme.breakpoints.up('sm')]: {
            display: 'flex',
        },
    },
    sectionMobile: {
        display: 'flex',
        [theme.breakpoints.up('sm')]: {
            display: 'none',
        },
    },
    menuItem: {
        width: '250px',
        fontSize: '0.875rem',
        fontWeight: '500',
        "&:hover": {
            color: theme.palette.primary.main,
        },
    },
    profile: {
        alignSelf: 'center',
        height: 64,
        textTransform: 'none',
    },
    avatar: {
        color: theme.palette.getContrastText(theme.palette.primary.main),
        backgroundColor: theme.palette.primary.main,
    },
    avatarSmall: {
        color: theme.palette.getContrastText(theme.palette.primary.main),
        backgroundColor: theme.palette.primary.main,
        width: theme.spacing(3.5),
        height: theme.spacing(3.5),
        fontSize: 15,
    },
    profileName: {
        alignSelf: 'center',
        marginBottom: 0,
    },
    profileNameLabel: {
        marginLeft: theme.spacing(1),
        color: 'black',
        marginBottom: 0,
    },
    menuButton: {
        [theme.breakpoints.up('md')]: {
            display: 'none',
        },
        [theme.breakpoints.down('xs')]: {
            marginRight: theme.spacing(1)
        },
        [theme.breakpoints.only('sm')]: {
            fontSize: "large"
        },
    },
    menuIcon: {
        [theme.breakpoints.only('sm')]: {
            fontSize: 30
        },
        //color: theme.palette.primary.main
    }
}));

export default useStyles;