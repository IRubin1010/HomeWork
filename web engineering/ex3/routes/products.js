let express = require('express');
let router = express.Router();
let bread = require('../data/products/bread');
let cheese = require('../data/products/cheese');


router.get('/', function(req, res){
    res.json({
        middlePage: "products.ejs",
        bread: bread,
        cheese: cheese,
    })
});

module.exports = router;