let express = require('express');
let router = express.Router();

router.get('/', function(req, res){
    res.json({
        middlePage: "about.ejs"
    });
});

module.exports = router;