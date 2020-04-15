import React, {useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {Redirect, useHistory} from "react-router-dom";

import Container from "@material-ui/core/Container";
import Avatar from "@material-ui/core/Avatar";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import useMediaQuery from "@material-ui/core/useMediaQuery/useMediaQuery";

import useStyles from "./SignUp.css";
import signUpAction from "../../Store/Actions/SignUp";
import FormValidator from '../../Utils/validation/formValidator'
import ValidationRule from '../../Utils/validation/validationRule'
import validationMethods from '../../Utils/validation/validationMethods'
import {ValidationResult} from '../../Utils/validation/validationResult'
import Typography from "@material-ui/core/Typography";
import * as moment from "moment";

const SignUp = (props) => {

    const isLoggedIn = useSelector(state => {
        const dateNow = moment().utc();
        const momentTokenExpiration = moment.unix(state.auth.tokenExpiration ?? undefined).utc();
        return !!(dateNow.isBefore(momentTokenExpiration));

    });

    const classes = useStyles();
    const dispatch = useDispatch();
    const history = useHistory();

    const isXSScreen = useMediaQuery(theme => theme.breakpoints.down('xs'));
    const isSMScreen = useMediaQuery(theme => theme.breakpoints.down('sm'));
    const maxWidth = useMediaQuery(theme => theme.breakpoints.up('xl')) ? 'lg' : 'md';

    const [validationStatus, setValidationStatus] = useState(new ValidationResult(true));
    const [user, setUser] = useState({});

    const formValidator = new FormValidator([
        new ValidationRule('firstName', validationMethods.isEmpty, [], false, 'First Name is required'),
        new ValidationRule('lastName', validationMethods.isEmpty, [], false, 'Last Name is required'),
        new ValidationRule('email', validationMethods.isEmpty, [], false, 'Email is required'),
        new ValidationRule('email', validationMethods.isEmail, [], true, 'should be a valid email'),
        new ValidationRule('phoneNumber', validationMethods.isEmpty, [], false, 'Phone Number is required'),
        new ValidationRule('phoneNumber', validationMethods.isPhoneNumber, [], true, 'should be a valid Phone Number'),
        new ValidationRule('password', validationMethods.isEmpty, [], false, 'Password is required'),
        new ValidationRule('password', validationMethods.minLength, [6], true, 'Password should be at least 6 characters'),
        new ValidationRule('password', validationMethods.arePasswordMatch, [], true, 'Password and Confirm Password are not matching'),
    ]);

    const inputChangedHandler = (event) => {
        event.preventDefault();
        const newUser = {
            ...user,
            [event.target.id]: event.target.value,
        };

        let validStatus = formValidator.validate(newUser);
        setValidationStatus(validStatus);
        setUser(newUser);
    };

    const passwordChangedHandler = (event) => {
        event.preventDefault();
        const newUser = {
            ...user,
            [event.target.id]: event.target.value,
        };

        if (newUser.password && newUser.confirmPassword) {
            let validStatus = formValidator.validate(newUser);
            setValidationStatus(validStatus);
        }
        setUser(newUser);
    };

    const handleFormSubmit = async (event) => {
        event.preventDefault();
        if (!validationStatus.isValid) {
            return; // TODO throw exception
        }

        let userToSubmit = {
            firstName: '',
            lastName: '',
            email: '',
            phoneNumber: '',
            address: '',
            city: '',
            zipCode: '',
            country: '',
            password: '',
            confirmPassword: '',
            ...user
        };

        let validStatus = formValidator.validate(userToSubmit);
        if (!validStatus.isValid) {
            setValidationStatus(validStatus);
            setUser(userToSubmit);
            return; // TODO throw exception
        }
        await dispatch(signUpAction(userToSubmit)) // TODO handle errors
    };

    if(isLoggedIn){
        return <Redirect to={'/'}/>
    }

    return (
        <Container component="main" maxWidth={maxWidth} className={classes.container}>
            <div className={classes.sectionDesktop}>
                <h1 style={{fontSize: '3.2rem'}}>
                    Welcome
                </h1>
                <h4>
                    Please Sign Up to join GeekStarter
                </h4>
            </div>
            <div className={classes.sectionMobile}>
                <h1>
                    Welcome
                </h1>
                <h5>
                    Please Sign Up to join GeekStarter
                </h5>
            </div>
            <form className={classes.form} noValidate onSubmit={handleFormSubmit}>
                <Grid container spacing={isXSScreen ? 3 : isSMScreen ? 4 : 5}>
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
                                                    helperText={validationStatus?.firstName?.message}
                                                    error={validationStatus?.firstName && !validationStatus?.firstName?.isValid}
                                                    onChange={inputChangedHandler}
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
                                                    helperText={validationStatus?.lastName?.message}
                                                    error={validationStatus?.lastName && !validationStatus?.lastName?.isValid}
                                                    onChange={inputChangedHandler}
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
                                                    helperText={validationStatus?.email?.message}
                                                    error={validationStatus?.email && !validationStatus?.email?.isValid}
                                                    onChange={inputChangedHandler}
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
                                    autoComplete="phoneNumber"
                                    helperText={validationStatus?.phoneNumber?.message}
                                    error={validationStatus?.phoneNumber && !validationStatus?.phoneNumber?.isValid}
                                    onChange={inputChangedHandler}
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
                                    helperText={validationStatus?.password?.message}
                                    error={validationStatus?.password && !validationStatus?.password?.isValid}
                                    onChange={passwordChangedHandler}
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
                                    helperText={validationStatus?.password?.message}
                                    error={validationStatus?.password && !validationStatus?.password?.isValid}
                                    onChange={passwordChangedHandler}
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
                        disabled={!validationStatus.isValid}
                    >
                        Sign Up
                    </Button>
                </div>
                <Grid container justify="center" style={{marginBottom: 15}}>
                    <Grid item>
                        <Typography component="h6" variant="body2">
                            already have a
                            <span className={classes.brand}>
                                                &nbsp;GeekStarter&nbsp;
                            </span>
                            account ?
                            <span className={classes.link} onClick={() => {
                                history.push('/login')
                            }}>
                                                &nbsp;Log In
                            </span>
                        </Typography>
                    </Grid>
                </Grid>
            </form>
        </Container>
    );
};

export default SignUp;