let productDb = require('../model')('product');


async function getProducts(){
    try {
        let dbProducts =  await productDb.find({}).exec();
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


async function updateProduct (product){
    try{
    let fieldsToUpdate = { description: product.description, price: product.price };
    await productDb.findOneAndUpdate({ image: product.image , catagory: product.catagory }, fieldsToUpdate, { new: true }).exec();
    return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.getBreads = getBreads;
module.exports.getProducts = getProducts;
module.exports.updateProduct = updateProduct;
