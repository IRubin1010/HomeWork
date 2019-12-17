let productDb = require('../model')('product');

async function getProducts(){
    try {
        return await productDb.find({}).exec();
    }catch (err) {
        console.log(err);
        return [];
    }
}

async function getBreads(){
    try{
        return await productDb.find({catagory: 'bread'}).exec();
    } catch(err) {
        console.log (err);
        return [];
    }
}

module.exports.getBreads = getBreads;
module.exports.getProducts = getProducts;
