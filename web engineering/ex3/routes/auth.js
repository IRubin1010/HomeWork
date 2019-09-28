let express = require('express');
let router = express.Router();
let users = require('../data/users');

router.post('/', function(req, res){
    let userName = req.body.userName;
    let password = req.body.password;
    let user = users.filter(user => {
        return user.userName === userName && user.password === password
    })[0];
    if(user !== undefined){
        res.send('OK');
    }else{
        res.status(401).send({errMsg: "authorization failed"});
    }
});

module.exports = router;