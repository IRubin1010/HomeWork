let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');
let passport = require('passport');


router.post('/login', passport.authenticate("local"), authService.authenticate, async function(req, res){
    res.sendStatus(200)
});

router.get('/logout', authService.authenticate, async function(req, res){
    req.session.destroy();
    res.sendStatus(200)
});

router.get('/userRole', authService.authenticate, function(req, res){
    res.status(200).json({
        userRole: req.user.role
    });
});

router.get('/userName', authService.authenticate, function(req, res){
    res.status(200).json({
        userName: req.user.userName
    });
});

module.exports = router;