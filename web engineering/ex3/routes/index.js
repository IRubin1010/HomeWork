let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');

router.get('/', function (req, res) {

    let userName = req.query.userName;
    let password = req.query.password;

    let userRole = undefined;

    if (userName !== undefined && password !== undefined) {
        let user = authService.getUser(userName, password);
        if (user !== undefined) {
            userRole = user.role;
        }
    }
    res.render(`pages/index`, {
        middlePage: "firstPage.ejs",
        userRole: userRole
    })
});

module.exports = router;