import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
    paper: {
        marginTop: 0,
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        [theme.breakpoints.up('sm')]: {
            marginTop: theme.spacing(4),
        },
        [theme.breakpoints.up('xl')]: {
            marginTop: theme.spacing(12),
        },
    },
    avatar: {
        width: 130,
        height: 130,
        display: 'block',
        margin: 'auto',
        [theme.breakpoints.up('sm')]: {
            width: 180,
            height: 180,
        },
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(3),
    },
    submit: {
        maxWidth: "350px",
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
}));

export default useStyles;