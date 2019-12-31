let express = require('express');
let router = express.Router();
let userRepository = require('../repositories/userRepository');
let usersService = require('../BL/usersService');
let authService = require('../BL/authService');

router.use(authService.checkLoggedIn);

router.get('/administratorData', authService.checkAdmin, async function (req, res) {
    let users = await userRepository.getUsers();
    res.json({
        middlePage: "users.ejs",
        users: users,
        template: "user.ejs"
    })
});

router.get('/workerData', authService.checkWorker, async function (req, res) {

    let users = await userRepository.getUsers();
    let filteredUsers = users.filter(user => {
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

router.post('/add', authService.checkAdminOrWorker, async function (req, res) {

    let user = req.body.user;
    let isNotValidUser = await userRepository.validetUser(user);
    if (isNotValidUser !== null) {
        res.sendStatus(403);
    } else {
        let isUserAdded = await userRepository.adduser(user);
        if (!isUserAdded) {
            res.sendStatus(500);
        } else {
            res.sendStatus(200);
        }
    }
});

router.post('/delete', authService.checkAdmin, async function (req, res) {

    let user = req.body.user;

    let isUserDeleted = await userRepository.deleteUser(user);

    if (!isUserDeleted) {
        res.sendStatus(500);
    } else {
        res.sendStatus(200);
    }
});


router.post('/update', authService.checkAdmin, async function (req, res) {

    let updatedUser = req.body.updatedUser;

    let isUserUpdated = await userRepository.updateUser(updatedUser);

    if (!isUserUpdated) {
        res.sendStatus(500);
    } else {
        res.sendStatus(200);
    }
});

module.exports = router;