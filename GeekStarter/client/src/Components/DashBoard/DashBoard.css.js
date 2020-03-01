import makeStyles from "@material-ui/core/styles/makeStyles";

export const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
    },
    topProjectGrid: {
        [theme.breakpoints.up('md')]: {
            borderRight: '1px lightGray solid'
        }
    },
    divider: {
        marginTop: '10px',
        marginBottom: '10px',
        marginLeft: '3vw',
        marginRight: '3vw',
        [theme.breakpoints.up('sm')]: {
            marginLeft: '4vw',
            marginRight: '4vw',
        },
    }
}));


export const hrCardStyle = {
    cardClass: {
        flexDirection: 'unset',
        maxHeight: '6.5rem',
        isUpSm: {
            paddingLeft: '4vw',
            paddingRight: '5vw',
        },
    },
    mediaClass: {
        paddingTop: '0',
        width: '30%',
    },
    contentClass: {
        width: '60%',
        paddingLeft: '20px',
        paddingRight: 0,
        paddingTop: 0,
        isUpSm: {
            paddingLeft: '40px',
        },
    },
    textDescription: {
        paddingTop: 0,
        isUpSm: {
            paddingTop: '10px',
        },
    }
};

export const topProjectCardStyle = {
    textDescription: {
        fontSize: '0.9rem'
    }
};
