let express = require('express');
let router = express.Router();


router.post('/login', function(req, res, next) {
    console.log(req);
    res.render('index', { title: 'Express' });
});

module.exports = router;
