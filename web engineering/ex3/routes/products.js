let express = require('express');
let router = express.Router();
let bread = require('../data/products/bread');
let cheese = require('../data/products/cheese');
let vegetables = require('../data/products/vegetables');
let fruits = require('../data/products/fruits');
let meat = require('../data/products/meat');

router.get('/', function(req, res){

    res.json({
        middlePage: "products.ejs",
        template: "productsCatalog.ejs",
        bread: bread,
        cheese: cheese,
        vegetables: vegetables,
        fruits: fruits,
        meat: meat,
    })
});

module.exports = router;