let express = require('express');
let router = express.Router();

router.get('/', function(req, res){
    res.render(`pages/index`, {page: "firstPage.ejs"})
});

module.exports = router;