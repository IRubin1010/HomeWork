let express = require('express');
let router = express.Router();
//let bread = require('../data/products/bread');
let cheese = require('../data/products/cheese');
let vegetables = require('../data/products/vegetables');
let fruits = require('../data/products/fruits');
let meat = require('../data/products/meat');
let authService = require('../BL/authService');
let productRepository = require('../repositories/productRepository');

router.use(authService.checkLoggedIn);

router.get('/', async function (req, res) {


    let products = await productRepository.getProducts();
    let groupsProducts = groupBy(products, p => p.catagory)

    res.json({
        middlePage: "products.ejs",
        template: "productsCatalog.ejs",
        bread: groupsProducts.get("bread"),
        cheese: groupsProducts.get("cheese"),
        vegetables: groupsProducts.get("vegetables"),
        fruits: groupsProducts.get("fruits"),
        meat: groupsProducts.get("meat"),
    })
});

router.get('/productsData', async function (req, res) {
    let products = await productRepository.getProducts();
    res.json({
        middlePage: "productsManage.ejs",
        products: products,
        template: "productManage.ejs"
    });
});

router.post('/update', authService.checkAdminOrWorker, async function (req, res) {

    let updatedProduct = req.body.updatedProduct;

    let isProductUpdated = await productRepository.updateProduct(updatedProduct);

    if (!isProductUpdated) {
        res.sendStatus(500);
    } else {
        res.sendStatus(200);
    }
});

module.exports = router;

function groupBy(list, keyGetter) {
    const map = new Map();
    list.forEach((item) => {
        const key = keyGetter(item);
        const collection = map.get(key);
        if (!collection) {
            map.set(key, [item]);
        } else {
            collection.push(item);
        }
    });
    return map;
}
