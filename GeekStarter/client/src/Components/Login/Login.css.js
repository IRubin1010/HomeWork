import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    container:{
        [theme.breakpoints.down('sm')]: {
            paddingLeft: 0,
            paddingRight: 0
        },
    },
    paper: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        [theme.breakpoints.up('sm')]: {
            marginTop: theme.spacing(8),
        },
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.secondary.main,
        [theme.breakpoints.up('sm')]: {
            width: 65,
            height: 65,
        },
    },
    lockIcon:{
        [theme.breakpoints.up('sm')]: {
            width: '2.5rem',
            height: '2.5rem',
        },
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    submit: {
        margin: theme.spacing(1, 0, 2),
        [theme.breakpoints.up('sm')]: {
            margin: theme.spacing(3, 0, 2),
        },
    },
    link:{
        color: 'black',
        textDecoration: 'none',
        "&:hover" :{
            cursor: 'pointer'
        }
    }
}));

export default useStyles;