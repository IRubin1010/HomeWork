let express = require('express');
let router = express.Router();
let usersService = require('../BL/usersService');

router.get('/administratorData', async function(req, res){
    let users = await usersService.getUsers();
    res.json({
        middlePage: "users.ejs",
        users: users,
        template: "user.ejs"
    })
});

router.get('/workerData', async function(req, res){

    let users = await usersService.getUsers();
    let filteredUsers = users.filter(user =>{
        return user.state === "active";
    }).map(user => {
        let returnUser = {
            userName: user.userName,
            mail: user.mail,
            role: user.role,
        };
        return returnUser;
    });
    res.json({
        middlePage: "users.ejs",
        users: filteredUsers,
        template: "user.ejs"
    })
});

router.post('/add', async function(req, res){

    let user = req.body.user;

    let isValidUser = await usersService.validetUser(user);

    if(isValidUser !== undefined){
        res.sendStatus(403);
    }
    else {
        let isUserAdded = await usersService.addUser(user);

        if(!isUserAdded){
            res.sendStatus(500);
        }else{
            res.sendStatus(200);
        }
    }
});

router.post('/delete', async function(req, res){

    let user = req.body.user;

    let isUserDeleted = await usersService.deleteUser(user);

    if(!isUserDeleted){
        res.sendStatus(500);
    }else{
        res.sendStatus(200);
    }
});


router.post('/update', async function(req, res){

    let updatedUser = req.body.updatedUser;

    let isUserUpdated = await usersService.updateUser(updatedUser);

    if(!isUserUpdated){
        res.sendStatus(500);
    }else{
        res.sendStatus(200);
    }
});

module.exports = router;