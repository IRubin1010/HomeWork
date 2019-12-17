let productDb = require('../model')('product');

module.exports.getProducts = async () => {
    console.log("--------tProducts---------");
    try {
        let products = await productDb.find({}).exec();
        return products;
    }catch (err) {
        console.log(err);
        return [];
    }
};

module.exports.getBreads = async () => {
    console.log("--------getBreads---------");
    try{
        let breads = await productDb.find({catagory: 'bread'}).exec();
        return breads;
    } catch(err) {
        console.log (err);
        return [];
    }
};
