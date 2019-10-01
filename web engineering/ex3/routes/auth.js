let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');

router.post('/', function(req, res){
    let userName = req.body.userName;
    let password = req.body.password;
    let user = authService.getUser(userName, password);
    if(user !== undefined){
        res.send('OK');
    }else{
        res.status(401).send({errMsg: "authorization failed"});
    }
});

module.exports = router;