let express = require('express');
let router = express.Router();
let products = require('../data/productsCatalog');

router.get('/', function(req, res){
    res.json({
        middlePage: "products.ejs",
        products: products
    })
});

module.exports = router;