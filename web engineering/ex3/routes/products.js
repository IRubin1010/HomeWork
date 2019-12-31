let express = require('express');
let router = express.Router();
let authService = require('../BL/authService');
let productRepository = require('../repositories/productRepository');
var multer = require('multer');
var fs = require("fs");
const download = require('image-downloader');
let path = './public/images';

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

var uploadImgHandler = multer({
    storage: multer.diskStorage
        ({
            destination: function (req, file, callback) {
                callback(null, path);
            },
            filename: function (req, file, callback) {
                callback(null, file.originalname);
            }
        })
}).single('product-image');

router.post('/add', authService.checkAdminOrWorker,uploadImgHandler, async function (req, res) {
    try {
        let url = req.body.product.imageUrl;
        let product = req.body.product;
        let isNotValidProduct = await productRepository.validetProduct(product);
        if (isNotValidProduct !== null) {
            res.sendStatus(403);
        } else {
            imageTempPath = await downloadImage({ url: url, dest: path })
            let mimetype = 'image/jpeg';
            try {
                await saveImage(imageTempPath, req.body.product, mimetype, res);
                res.status(200).send('OK');
            } catch (err) {
                console.log('ERROR: ' + err.message);
                res.status(500).send('ERROR');
            } finally {
                // Remove image from images folder
                fs.unlinkSync(imageTempPath);
            }
        }
    } catch (err) { // TODO: send the error message and show it to the user...
        console.log(err.message)
        res.status(500).send(err.message);
    }
});

const downloadImage = async (options) => {
    try {
        const { filename, image } = await download.image(options);
        console.log(`Downloading image: ${filename} finish successfully.`);
        return filename;
    } catch (err) {
        console.error(err);
    }
};

const saveImage = async (tempPath, details, mimetype, res) => {
    let fileContent = fs.readFileSync(tempPath);
    let encodeFile = fileContent.toString('base64');
    let image = {
        contentType: mimetype,
        data: new Buffer(encodeFile, 'base64')
    };

    let product = {
        description: details.description,
        price: details.price,
        image: image,
        catagory: details.catagory
    };

    let isProductAdded = await productRepository.addProduct(product);
    if(!isProductAdded){
        res.sendStatus(500);
    } else {
        res.sendStatus(200);
    }
};

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
