const express = require('express');
const authService = require("../services/authService");
const router = express.Router();

router.post('/login', authService.login);

router.post('/register', async (req, res, next) => {
    let newUser = req.body.user;
    try {
        await authService.register(newUser);
        //res.status(200).end();
        req.body.email = newUser.email;
        req.body.password = newUser.password;
        next();
    }catch (err) {
        res.status(400).send(err);
    }
}, authService.login);

router.post('/logout', async (req, res, next) => {
    req.logOut();
    res.clearCookie('token');
    res.sendStatus(200);
});


module.exports = router;