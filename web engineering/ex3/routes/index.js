let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');
let helperRepository = require('../repositories/helperRepository');

router.get('/', async function (req, res) {

    let userName = req.query.userName;
    let password = req.query.password;

    let userRole = await authService.getUserRole(userName, password);
    //let x = await helperRepository.initDB();

    res.render(`pages/index`, {
        middlePage: "firstPage.ejs",
        userRole: userRole
    })
});

module.exports = router;