let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');

router.post('/', async function(req, res){
    let userName = req.body.userName;
    let password = req.body.password;
    let isUserAuthorized = await authService.authorizeUser(userName, password);
    if(isUserAuthorized){
        res.send('OK');
    }else{
        res.status(401).send({errMsg: "authorization failed"});
    }
});

router.post('/userRole', async function(req, res){
    let userName = req.body.userName;
    let password = req.body.password;
    let userRole = await authService.getUserRole(userName, password);
    if(userRole !== undefined){
        res.status(200).json({
            userRole: userRole
        });
    }else{
        res.status(401).send({errMsg: "authorization failed"});
    }
});

module.exports = router;