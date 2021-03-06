let productDb = require('../model')('product');


async function getProducts(){
    try {
        let dbProducts =  await productDb.find({}).sort('catagory').exec();
        let products = dbProducts.map( product => {
            return {
                description: product.description,
                price: product.price,
                catagory: product.catagory,
                image: product.image.data.toString('base64')
            }
        });
        return products;
    }catch (err) {
        console.log(err);
        return [];
    }
}

async function getBreads(){
    try{
        let bread =  await productDb.find({catagory: 'bread'}).exec();
        result = bread.map( bread => {
            return {
                description: bread.description,
                price: bread.price,
                catagory: bread.catagory,
                image: bread.image.data.toString('base64')
            }
        });
        return result;
    } catch(err) {
        console.log (err);
        return [];
    }
}

async function addProduct (product){
    try{
    let createdProduct = await productDb.CREATE(product);
    console.log(`A new product created: ${createdProduct}`);
    return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

async function updateProduct (product){
    try{
    let fieldsToUpdate = {price: product.price };
    await productDb.findOneAndUpdate({ description: product.description , catagory: product.catagory }, fieldsToUpdate, { new: true }).exec();
    return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

async function validetProduct (productToVlidate) {
    try {
        let product =  await productDb.findOne({description: productToVlidate.description}).exec();
        return product;
    }catch (err) {
        console.log(err);
        return false;
    }
};

 async function deleteProduct (productToDelete) {
    try {
        await productDb.findOneAndDelete({description: productToDelete.description, price: productToDelete.price, catagory: productToDelete,catagory}).exec();
            return true;
        }catch (err) {
            console.log(err);
            return false;
        }
};

module.exports.validetProduct = validetProduct;
module.exports.addProduct = addProduct;
module.exports.getBreads = getBreads;
module.exports.getProducts = getProducts;
module.exports.updateProduct = updateProduct;
module.exports.deleteProduct = deleteProduct;


