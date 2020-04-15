import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    root: {
        // marginLeft: 'auto',
        // marginRight: 'auto',
        marginTop: 64
    },
    container: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        [theme.breakpoints.up('sm')]: {
            marginTop: theme.spacing(12),
        },
        [theme.breakpoints.up('xl')]: {
            marginTop: theme.spacing(20),
        },
    },
    avatar: {
        width: 130,
        height: 130,
        display: 'block',
        margin: 'auto',
        [theme.breakpoints.up('sm')]: {
            width: 150,
            height: 150,
        },
        [theme.breakpoints.up('md')]: {
            width: 180,
            height: 180,
        },
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(4),
    },
    submit: {
        maxWidth: "400px",
        marginTop: theme.spacing(4),
        marginLeft:"auto",
        marginRight: "auto",
        height: "50px",
        fontSize: "18px",
        marginBottom: theme.spacing(2),
        [theme.breakpoints.up('sm')]: {
            marginTop: theme.spacing(6),
        },
    },
    sectionDesktop: {
        display: 'none',
        textAlign: 'center',
        [theme.breakpoints.up('sm')]: {
            display: 'block',

        },
    },
    sectionMobile: {
        display: 'block',
        textAlign: 'center',
        [theme.breakpoints.up('sm')]: {
            display: 'none',
        },
    },
    brand: {
        color: theme.palette.primary.main,
        fontFamily: "Baloo",
    },
    link:{
        color: 'black',
        textDecoration: 'none',
        "&:hover" :{
            cursor: 'pointer',
            color: theme.palette.primary.main
        }
    },
}));

export default useStyles;