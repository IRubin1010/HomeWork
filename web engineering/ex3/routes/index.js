let express = require('express');
let router = express.Router();

router.get('/', function(req, res){
    res.render(`pages/index`, {page: "first.ejs"})
});

module.exports = router;