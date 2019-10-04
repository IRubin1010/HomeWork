let express = require('express');
let router = express.Router();
let stores = require('../data/stores');

router.get('/', function(req, res){
    res.json({
        middlePage: "stores.ejs",
        stores: stores
    })
});

module.exports = router;