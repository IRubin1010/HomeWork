let express = require('express');
let router = express.Router();
let productsCategory = require('../data/productsCategory');

router.get('/', function(req, res){
    res.json(productsCategory);
});

module.exports = router;