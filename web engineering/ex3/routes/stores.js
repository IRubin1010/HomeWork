let express = require('express');
let router = express.Router();
let stores = require('../data/stores');

router.get('/', function(req, res){
    res.json({
        page: "stores.ejs",
        stores: stores
    })
});

module.exports = router;