import React from "react";
import Dialog from "@material-ui/core/Dialog";
import DialogContent from "@material-ui/core/DialogContent";
import Container from "@material-ui/core/Container";
import CssBaseline from "@material-ui/core/CssBaseline";
import Avatar from "@material-ui/core/Avatar";
import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import Box from "@material-ui/core/Box";

import useMediaQuery from "@material-ui/core/useMediaQuery/useMediaQuery";

import LockOutlinedIcon from '@material-ui/icons/LockOutlined';

import useStyles from "./Login.css";

const Login = (props) => {

    let {open, onClose, onSignUpClick, onForgotPasswordClick} = props;

    const classes = useStyles();

    const isXSmallScreen = useMediaQuery(theme => theme.breakpoints.down('xs'));

    return (
        <div>
            <Dialog open={open} onClose={onClose}>
                <DialogContent>
                    <Container component="main" maxWidth="xs" className={classes.container}>
                        <CssBaseline/>
                        <div className={classes.paper}>
                            <Avatar className={classes.avatar}>
                                <LockOutlinedIcon className={classes.lockIcon}/>
                            </Avatar>
                            <Typography component="h1" variant="h5">
                                Sign in
                            </Typography>
                            <form className={classes.form} noValidate>
                                <TextField
                                    variant="outlined"
                                    margin="normal"
                                    required
                                    fullWidth
                                    id="email"
                                    label="Email Address"
                                    name="email"
                                    autoComplete="email"
                                    autoFocus
                                />
                                <TextField
                                    variant="outlined"
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="password"
                                    label="Password"
                                    type="password"
                                    id="password"
                                    autoComplete="current-password"
                                />
                                <FormControlLabel
                                    control={<Checkbox value="remember" color="primary"/>}
                                    label="Remember me"
                                />
                                <Button
                                    type="submit"
                                    fullWidth
                                    variant="contained"
                                    color="primary"
                                    className={classes.submit}
                                >
                                    Sign In
                                </Button>
                                <Grid container style={{marginBottom: 10}}>
                                    <Grid item xs>
                                        <Typography component="h6" variant="body2" className={classes.link} onClick={onForgotPasswordClick}>
                                            Forgot password?
                                        </Typography>
                                    </Grid>
                                    <Grid item>
                                        <Typography component="h6" variant="body2" className={classes.link} onClick={onSignUpClick}>
                                            Don't have an account? Sign Up
                                        </Typography>
                                    </Grid>
                                </Grid>
                            </form>
                        </div>
                        {isXSmallScreen ? null : <Box mt={8}/>}
                    </Container>
                </DialogContent>
            </Dialog>
        </div>
    );
};

export default Login;