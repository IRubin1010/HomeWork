
const debug = require("debug")("mongo:model");
const mongo = require('mongoose');
let user = require('./user');
let product = require('./product')


let db = mongo.createConnection();

(async () => {
    try {
        await db.openUri('mongodb://localhost:37017/Meir-Demo', { useFindAndModify: false });
    } catch (err) {
        debug(`Error while trying connecting to mongo DB: ${err}`);
    }
})();

debug('Pending to DB connection');

user(db);
product(db);

module.exports = model => db.model(model);