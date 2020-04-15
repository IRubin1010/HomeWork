const userService = require("./userService");
const passport = require('passport');
const LocalStrategy = require('passport-local').Strategy;
const passportJWT = require("passport-jwt");
const JWTStrategy   = passportJWT.Strategy;
const ExtractJWT = passportJWT.ExtractJwt;

passport.use('login', new LocalStrategy({
    usernameField: 'email',
    passwordField: 'password'
}, async (email, password, done) => {
    try {
        const user = await userService.getUserByEmailWithPassword(email);
        if (!user) {
            return done(null, false, {message: 'User not found'});
        }
        const validate = await userService.validateUserPassword(user,password);
        if (!validate) {
            return done(null, false, {message: 'Wrong Password'});
        }
        return done(null, user, {message: 'Logged in Successfully'});
    } catch (error) {
        return done(error);
    }
}));

const cookieExtractor = (req) => {
    let token = null;
    if (req && req.cookies)
    {
        token = req.cookies['token'];
    }
    return token;
};

passport.use(new JWTStrategy({
        jwtFromRequest: ExtractJWT.fromExtractors([cookieExtractor]),
        secretOrKey   : 'top_secret'
    },
    async (jwtPayload, done) => {
        try {
            const user = await userService.getUserById(jwtPayload.user.id);
            if (!user) {
                return done(null, false, {message: 'User not found'});
            }
            if (user.email !== jwtPayload.user.email) {
                return done(null, false, {message: 'Wrong mail for user'});
            }
            return done(null, user, {message: 'Logged in Successfully'});
        } catch (error) {
            return done(error);
        }
    }
));