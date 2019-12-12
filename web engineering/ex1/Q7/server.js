// reference the http module so we can create a webserver
let http = require("http");
let path = require("path");
let express = require('express');
let app = express();
var counter = 1;
var current = new Date();

app.use(express.static(path.join(__dirname, 'public')));
app.all('/', function (req, res) {
    current.setSeconds(current.getSeconds() + 10);
    res.writeHead(200, "ok", {
        'Set-Cookie': 'mycookie=Meir cookie',
        'Server': 'MYNODE.JS',
        'Date': current,
        'X-Powered-By': 'NODE',
        'Cache-Control': 'no-cache, no-store',
        'Expires': '-1',
        'Content-Type': 'text/html; charset=utf-8',
        'Content-Length': '14990',
    });
    res.write('Hello World\n');

    res.send();
});
app.listen(8081, function () {
    console.log('Example app listening on port 8081!')
});


