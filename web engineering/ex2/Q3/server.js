// reference the http module so we can create a webserver
let http = require("http");
let path = require("path");
let express = require('express');
let app = express();
app.use(express.static(path.join(__dirname, 'public')));

app.post('/', function (req, res) {
});
app.listen(8080, function () {
  console.log('listening on port 8080!')
});