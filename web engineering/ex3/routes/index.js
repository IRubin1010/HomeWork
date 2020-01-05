let express = require('express');
let router = express.Router();

router.get('/', async function (req, res) {
    let userRole = undefined;
    if(req.isAuthenticated()){
        console.log("Authenticated");
        userRole = req.user.role;
    }
    res.render(`pages/index`, {
        middlePage: "firstPage.ejs",
        userRole: userRole
    })
});

module.exports = router;