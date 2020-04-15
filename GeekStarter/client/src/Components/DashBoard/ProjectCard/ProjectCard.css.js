import makeStyles from "@material-ui/core/styles/makeStyles";

const useStyles = makeStyles(theme => ({
    card:{
        display: 'flex',
        flexDirection: 'column',
    },
    media: {
        paddingTop: '60%', // 16:9
    },
    content: {
    },
    textTitle: {
    },
    textDescription: {
        paddingTop: '10px',
    },
    textFooter: {
        paddingTop: '7px',
    },
}));

export default useStyles;