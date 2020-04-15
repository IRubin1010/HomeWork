const mongoose = require('mongoose');

mongoose.connect('mongodb://localhost:27017/GeekStarter', {useNewUrlParser: true});
const db = mongoose.connection;

db.on("error", (err) => {
    console.log(`error occurred while connecting to db. err={${err}`);
});
db.once("open", () => {
    console.log("successfully opened the db");
});

module.exports = mongoose;
