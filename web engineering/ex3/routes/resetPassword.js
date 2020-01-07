let express = require('express');
let router = express.Router();
let mailer = require('./../config/mailing');
let uuid = require('uuid/v4');
let userRepository = require('./../repositories/userRepository');
let rsa  = require('./../config/rsa');
let bcrypt = require('bcryptjs');

router.post('/request', async function(req, res){
    let email = req.body.email;

    let user = await userRepository.findByEmail(email);
    if (user) {
        let token = uuid();
        user.resetToken = token;
        user.resetTokenExpires = Date.now() + 3600000;
        await user.save();

        console.log(email);

        let mailOptions = {
            from: 'dontReply', // sender address
            to: email, // list of receivers
            subject: 'to reset your password follow the follow the link', // Subject line
            html: `<p>http://localhost:3000/resetPassword?user=${user.userName}&token=${token}</p>`// plain text body

        };
        mailer.sendMail(mailOptions, function (err, info) {
            if (err)
                console.log(err);
            else
                res.status(200).send("check your email")
        });
    }else {
        res.status(404).send("could not fail user with such email");
    }
});

router.post('/', async function(req, res){
    let userName = req.body.user;
    let token = req.body.token;
    let password = req.body.password;
    password = rsa.DecryptPassword(password);

    let user = await userRepository.findByUserNameAndToken(userName, token);

    if (user) {

        let originPass = (' ' + password).slice(1);
        let salt = bcrypt.genSaltSync(10);
        user.password = bcrypt.hashSync(password, salt);
        if(!validatePassword(originPass)){
            res.sendStatus(403);
        }else {
            await user.save();
            res.send("OK");
        }
    } else {
        res.status(404).send("this email is not registered");
    }
});

router.get('/', async function (req, res) {
    let userName = req.query.user;
    let token = req.query.token;
    let user = await userRepository.findByUserNameAndToken(userName, token);
    if (user) {
        res.render(`pages/resetPassword`)
    } else {
        res.status(401).send("Not authorized");
    }
});

module.exports = router;

function validatePassword(password){
    console.log(password);
    return password.length >=4 && password.length <=8;
}