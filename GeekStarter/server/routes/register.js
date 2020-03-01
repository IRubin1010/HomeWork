let express = require('express');
let router = express.Router();


router.post('/', function(req, res, next) {
    console.log(req.body);
    res.send('respond with a resource');
});

module.exports = router;
