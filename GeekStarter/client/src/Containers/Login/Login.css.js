import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    root: {
        marginLeft: 'auto',
        marginRight: 'auto',
        marginTop: 64
    },
    container:{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        marginTop: theme.spacing(15),
        [theme.breakpoints.up('sm')]: {
            paddingLeft: theme.spacing(0),
            paddingRight: theme.spacing(0),
        },
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(4),
    },
    submit: {
        margin: theme.spacing(1,0,2,0),
        height: "50px",
        fontSize: "18px",
        [theme.breakpoints.up('sm')]: {
            margin: theme.spacing(2,0,2,0),
        },
        [theme.breakpoints.up('xl')]: {
            margin: theme.spacing(5,0,2,0),
        },
    },
    link:{
        color: 'black',
        textDecoration: 'none',
        "&:hover" :{
            cursor: 'pointer',
            color: theme.palette.primary.main
        }
    },
    brand: {
        color: theme.palette.primary.main,
        fontFamily: "Baloo",
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
}));

export default useStyles;