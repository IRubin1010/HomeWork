import makeStyles from "@material-ui/core/styles/makeStyles";

const useStyles = makeStyles(theme => ({
    image: {
        height: '230px',
        width: '100%',
        objectFit: 'cover',
        [theme.breakpoints.up('sm')]: {
            height: '300px',
        },
        [theme.breakpoints.up('md')]: {
            height: '450px',
        },
        filter: 'brightness(60%)',
        WebkitFilter: 'brightness(60%)'
    },
    caption:{
        textAlign: 'left',
        color: theme.palette.primary.main
    },
    title:{
        fontWeight: '600',
        fontSize: "1.5rem",
        marginBottom: 0,
        [theme.breakpoints.up('sm')]: {
            fontWeight: '600',
            fontSize: "2.8rem",
        },
    },
    description:{
        fontSize: "1rem",
        [theme.breakpoints.up('sm')]: {
            fontSize: "1.6rem",
        },
    }
}));

export default useStyles;