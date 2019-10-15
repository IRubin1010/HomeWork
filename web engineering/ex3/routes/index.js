let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');

router.get('/', async function (req, res) {

    let userName = req.query.userName;
    let password = req.query.password;

    let userRole = await authService.getUserRole(userName, password);

    res.render(`pages/index`, {
        middlePage: "firstPage.ejs",
        userRole: userRole
    })
});

module.exports = router;