import React from "react";

import Container from "@material-ui/core/Container";
import CssBaseline from "@material-ui/core/CssBaseline";
import Avatar from "@material-ui/core/Avatar";
import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";

import useStyles from "./SignUp.css";
import Link from "@material-ui/core/Link";
import useMediaQuery from "@material-ui/core/useMediaQuery/useMediaQuery";

import axios from "../../axios";


const SignUp = (props) => {

    const classes = useStyles();

    const isSmallScreen = useMediaQuery(theme => theme.breakpoints.down('xs'));
    const maxWidth = useMediaQuery(theme => theme.breakpoints.up('xl')) ? 'lg' : 'md';

    const handleFormSubmit = async (event) => {
        event.preventDefault();
        let user = {
            firstName: event.target.firstName.value,
            lastName: event.target.lastName.value,
            email: event.target.email.value,
            phoneNumber: event.target.phoneNumber.value,
            address: event.target.address.value,
            city: event.target.city.value,
            zipCode: event.target.zipCode.value,
            country: event.target.country.value,
            password: event.target.password.value
        };
        let res = await axios.post('/register', {user: user});
        console.log(res);
    };

    return (
        <Container component="main" maxWidth={maxWidth}>
            <CssBaseline/>

            <div className={classes.paper}>
                <Typography component="h1" variant="h2" style={{fontFamily: 'Baloo', marginBottom: 20, marginTop: 20}}>
                    Sign Up
                </Typography>
                <form className={classes.form} noValidate onSubmit={handleFormSubmit}>
                    <Grid container spacing={isSmallScreen ? 3 : 5}>
                        <Grid item sm xs={12}>
                            <Grid container spacing={3}>
                                <Grid item>
                                    <Grid container spacing={3}>
                                        <Grid container item sm xs={12}>
                                            <Avatar alt="Remy Sharp" src="/picture1.jpg"
                                                    className={classes.avatar}/>
                                        </Grid>
                                        <Grid item sm xs={12}>
                                            <Grid container spacing={3}>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        autoComplete="fname"
                                                        name="firstName"
                                                        variant="outlined"
                                                        required
                                                        fullWidth
                                                        id="firstName"
                                                        label="First Name"
                                                        autoFocus
                                                    />
                                                </Grid>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        variant="outlined"
                                                        required
                                                        fullWidth
                                                        id="lastName"
                                                        label="Last Name"
                                                        name="lastName"
                                                        autoComplete="lname"
                                                    />
                                                </Grid>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        variant="outlined"
                                                        required
                                                        fullWidth
                                                        id="email"
                                                        label="Email Address"
                                                        name="email"
                                                        autoComplete="email"
                                                    />
                                                </Grid>
                                            </Grid>
                                        </Grid>
                                    </Grid>
                                </Grid>
                                <Grid item xs={12}>
                                    <TextField
                                        variant="outlined"
                                        required
                                        fullWidth
                                        id="phoneNumber"
                                        label="Phone Number"
                                        name="phoneNumber"
                                        autoComplete="email"
                                    />
                                </Grid>
                            </Grid>

                        </Grid>

                        <Grid item sm xs={12}>
                            <Grid container spacing={3}>
                                <Grid item sm xs={12}>
                                    <Grid container spacing={3}>
                                        <Grid item sm xs={12}>
                                            <Grid container spacing={3}>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        variant="outlined"
                                                        fullWidth
                                                        name="address"
                                                        label="Address"
                                                        id="address"
                                                    />
                                                </Grid>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        variant="outlined"
                                                        fullWidth
                                                        name="zipCode"
                                                        label="Zip Code"
                                                        id="zipCode"
                                                    />
                                                </Grid>
                                            </Grid>
                                        </Grid>
                                        <Grid item sm xs={12}>
                                            <Grid container spacing={3}>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        variant="outlined"
                                                        fullWidth
                                                        name="city"
                                                        label="City"
                                                        id="city"
                                                    />
                                                </Grid>
                                                <Grid item xs={12}>
                                                    <TextField
                                                        variant="outlined"
                                                        fullWidth
                                                        name="country"
                                                        label="Country"
                                                        id="country"
                                                    />
                                                </Grid>
                                            </Grid>
                                        </Grid>
                                    </Grid>
                                </Grid>

                                <Grid item xs={12}>
                                    <TextField
                                        variant="outlined"
                                        required
                                        fullWidth
                                        name="password"
                                        label="Password"
                                        type="password"
                                        id="password"
                                        autoComplete="current-password"
                                    />
                                </Grid>
                                <Grid item xs={12}>
                                    <TextField
                                        variant="outlined"
                                        required
                                        fullWidth
                                        name="confirmPassword"
                                        label="confirm Password"
                                        type="password"
                                        id="confirmPassword"
                                        autoComplete="current-password"
                                    />
                                </Grid>
                            </Grid>
                        </Grid>
                    </Grid>
                    <div style={{display: "flex"}}>
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            color="primary"
                            className={classes.submit}
                        >
                            Sign Up
                        </Button>
                    </div>
                    <Grid container justify="center" style={{marginBottom: 15}}>
                        <Grid item>
                            <Link href="#" variant="body2">
                                Already have an account? Sign in
                            </Link>
                        </Grid>
                    </Grid>
                </form>
            </div>
        </Container>
    );
};

export default SignUp;