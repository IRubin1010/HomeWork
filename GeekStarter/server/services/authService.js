const userService = require("./userService");
const passport = require('passport');
const jwt = require('jsonwebtoken');
const moment = require('moment');
const passportService = require('./passportService'); // init passport DO NOT REMOVE

const register = async (user) => {
    if (!await userService.validateUserExist(user)) {
        throw 'user already exist';
    } else {
        try {
            await userService.addUser(user);
        } catch (err) {
            throw 'failed to create user';
        }
    }
};

const login = async (req,res,next) => {
    passport.authenticate('login', async (err, user, info) => {
        try {
            if (err) {
                console.log(`[loginRoute:login] error occurred during login. err={${err}}.`);
                return res.status(500).send('An Error occurred');
            }
            if (!user) {
                return res.status(401).send('email or password are incorrect');
            }
            req.login(user, {session: false}, async (error) => {
                if (error) return next(error);
                const token = createToken(user._id,user.email);
                res.cookie('token', token, {
                    expires: moment(Date.now()).add(1, 'h').toDate(),
                    secure: false, // set to true if your using https
                    httpOnly: true,
                });

                res.json({
                    ...req.user.toObject(),
                    _id: undefined,
                    created: undefined,
                    lastUpdate: undefined,
                    password: undefined,
                    token: token
                });
            });
        } catch (error) {
            console.log(`[loginRoute:login] error occurred during login. err={${err}}.`);
            return res.status(500).send('An Error occurred');
        }
    })(req, res, next);
};

const createToken = (userId, email) => {
    const body = {id: userId, email: email};
    return jwt.sign({user: body}, 'top_secret',{
        expiresIn: '1h'
    });
};

const setTokenCookies = (req, res, next) => {
    if(req.user === null || req.user === undefined){
        res.status(400).end();
    }
    const token = createToken(req.user._id,req.user.email);
    res.cookie('token', token, {
        expires: moment(Date.now()).add(1, 'h').toDate(),
        secure: false, // set to true if your using https
        httpOnly: true,
    });
    res.token = token;
    next();
};


module.exports = {
    register,
    login,
    setTokenCookies
};



