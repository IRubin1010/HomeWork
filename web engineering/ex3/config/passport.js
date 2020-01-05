let Strategy = require('passport-local').Strategy;
let userRepository = require('../repositories/userRepository');
let bcrypt = require('bcryptjs');
// let CryptoJS = require("crypto-js");
let rsa  = require('./rsa');

function initPassport(passport) {
    passport.use("local", new Strategy({usernameField: 'userName'},
        async function (username, password, done) {

            // let a = CryptoJS.AES.encrypt(password, 'secret key 123').toString();
            // console.log(a);
            // let b = CryptoJS.AES.decrypt(a, 'secret key 123');
            // let decryptedData = JSON.parse(b.toString(CryptoJS.enc.Utf8));
            // console.log(decryptedData);

            // let a = CryptoJS.MD5.encrypt(password).toString();
            // console.log(a);
            // let b = CryptoJS.MD5.decrypt(a);
            // console.log(b);
            // let decryptedData = JSON.parse(b.toString(CryptoJS.enc.Utf8));
            // console.log(decryptedData);

            let p = rsa.DecryptPassword(password);

            let user = await userRepository.getUserByUserName(username);
            if (!user) {
                return done(null, false);
            }
            if (!bcrypt.compareSync(p, user.password)) {
                return done(null, false);
            }
            return done(null, user);
        }));

    passport.serializeUser(function (user, done) {
        done(null, user.id);
    });

    passport.deserializeUser(async function (id, done) {
        let user = await userRepository.findById(id);
        if (!user) {
            return done(null, false);
        }
        done(null, user);
    });

}

module.exports.initPassport = initPassport;
