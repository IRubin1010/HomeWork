
const debug = require("debug")("mongo:model");
const mongo = require('mongoose');
let user = require('./user');


let db = mongo.createConnection();

(async () => {
    try {
        await db.openUri('mongodb://localhost/flower-shop-web-demo', { useFindAndModify: false });
    } catch (err) {
        debug(`Error while trying connecting to mongo DB: ${err}`);
    }
})();

debug('Pending to DB connection');

user(db);

module.exports = model => db.model(model);