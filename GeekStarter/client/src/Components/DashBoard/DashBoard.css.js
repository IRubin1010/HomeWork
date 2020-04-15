import makeStyles from "@material-ui/core/styles/makeStyles";

const useStyles = makeStyles(theme => ({
    root: {
        marginTop: 64,
        [theme.breakpoints.down('xs')]: {
            marginTop: '52px'
        }
    },
    container:{
        margin: 0,
        paddingRight: '8%',
        paddingLeft: '8%',
        [theme.breakpoints.down('xs')]: {
            paddingRight: 0,
            paddingLeft: 0,
        },
    },
}));


export default useStyles;