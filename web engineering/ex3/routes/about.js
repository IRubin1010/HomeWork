let express = require('express');
let router = express.Router();

router.get('/', function(req, res){
    res.json({
        page: "about.ejs"
    }) //render(`pages/index`, {page: "about.ejs"})
});

module.exports = router;