import React, {useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {useHistory, Redirect} from "react-router-dom";

import Container from "@material-ui/core/Container";
import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";

//import axios from '../../Api/Axios';
import useStyles from "./Login.css";
import Auth from "../../Store/Actions/Auth";
import FormValidator from "../../Utils/validation/formValidator";
import ValidationRule from "../../Utils/validation/validationRule";
import validationMethods from "../../Utils/validation/validationMethods";
import {ValidationResult} from "../../Utils/validation/validationResult";
import * as moment from "moment";
import DashBoard from "../../Components/DashBoard/DashBoard";

const Login = (props) => {

    const isLoggedIn = useSelector(state => {
        const dateNow = moment().utc();
        const momentTokenExpiration = moment.unix(state.auth.tokenExpiration ?? undefined).utc();
        return !!(dateNow.isBefore(momentTokenExpiration));

    });

    const classes = useStyles();
    const dispatch = useDispatch();
    const history = useHistory();

    const [validationStatus, setValidationStatus] = useState(new ValidationResult(true));
    const [form, setform] = useState({});

    const formValidator = new FormValidator([
        new ValidationRule('email', validationMethods.isEmpty, [], false, 'Email is required'),
        new ValidationRule('email', validationMethods.isEmail, [], true, 'should be a valid email'),
        new ValidationRule('password', validationMethods.isEmpty, [], false, 'Password is required'),
    ]);

    const inputChangedHandler = (event) => {
        event.preventDefault();
        const newUser = {
            ...form,
            [event.target.id]: event.target.value,
        };

        let validStatus = formValidator.validate(newUser);
        setValidationStatus(validStatus);
        setform(newUser);
    };

    const handleFormSubmit = async (event) => {
        event.preventDefault();
        if (!validationStatus.isValid) {
            return; // TODO throw exception
        }

        let formFields = {
            email: '',
            password: '',
            ...form
        };
        let validStatus = formValidator.validate(formFields);
        if (!validStatus.isValid) {
            setValidationStatus(validStatus);
            setform(formFields);
            return; // TODO throw exception
        }
        try {
            await dispatch(Auth.login(formFields.email, formFields.password));
        } catch (err) {
            console.log(err);
        }
        // try {
        //     await axios.get('/users');
        // }
        // catch (e) {
        //     console.log(e);
        // }

    };

    if(isLoggedIn){
        return <Redirect to={'/'}/>
    }

    return (
        // <div className={classes.root}>
            <Container component="main" maxWidth="xs" className={classes.container}>
                    <div className={classes.sectionDesktop}>
                        <h1 style={{fontSize: '3.2rem'}}>
                            Welcome Back
                        </h1>
                        <h4>
                            Please log In to continue
                        </h4>
                    </div>
                    <div className={classes.sectionMobile}>
                        <h1>
                            Welcome Back
                        </h1>
                        <h5>
                            Please log In to continue
                        </h5>
                    </div>
                    <form className={classes.form} noValidate onSubmit={handleFormSubmit}>
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
                            onChange={inputChangedHandler}
                            helperText={validationStatus?.email?.message}
                            error={validationStatus?.email && !validationStatus?.email?.isValid}
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
                            onChange={inputChangedHandler}
                            helperText={validationStatus?.password?.message}
                            error={validationStatus?.password && !validationStatus?.password?.isValid}
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
                                <Typography component="h6" variant="body2" className={classes.link}
                                            onClick={() => {
                                                history.push('/forgotPassword')
                                            }}>
                                    Forgot password?
                                </Typography>
                            </Grid>
                            <Grid item>
                                <Typography component="h6" variant="body2">
                                    new to
                                    <span className={classes.brand}>
                                                &nbsp;GeekStarter&nbsp;
                                            </span>
                                    ?
                                    <span className={classes.link} onClick={() => {
                                        history.push('/signUp')
                                    }}>
                                                &nbsp;Sign Up
                                            </span>
                                </Typography>
                            </Grid>
                        </Grid>
                    </form>
            </Container>
        // </div>
    );
};

export default Login;