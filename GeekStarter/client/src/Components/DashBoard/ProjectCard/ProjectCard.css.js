import makeStyles from "@material-ui/core/styles/makeStyles";

const useStyles = makeStyles(theme => ({
    card: props => ({
        display: 'flex',
        flexDirection: 'column',
        boxShadow: 'none',
        borderRadius: 'unset',
        paddingLeft: '3vw',
        paddingRight: '3vw',
        [theme.breakpoints.up('sm')]: {
            paddingLeft: '4vw',
            paddingRight: '4vw',
            ...(props.cardClass?.isUpSm)
        },
        ...props.cardClass,
    }),
    media: props => ({
        paddingTop: '60%', // 16:9
        ...props.mediaClass
    }),
    content: props => ({
        paddingLeft: 0,
        paddingRight: 0,
        [theme.breakpoints.up('sm')]: {
            ...(props.contentClass?.isUpSm)
        },
        ...props.contentClass
    }),
    textTitle: props => ({
        ...props.textTitle
    }),
    textDescription: props => ({
        paddingTop: '10px',
        [theme.breakpoints.up('sm')]: {
            ...(props.textDescription?.isUpSm)
        },
        ...props.textDescription
    }),
    textFooter: props => ({
        paddingTop: '7px',
        ...props.textFooter
    }),
}));

export default useStyles;