	// reference the http module so we can create a webserver
    let http = require("http");
    let path = require("path");
    let express = require('express');
    let app = express();
    	app.use(express.static(path.join(__dirname, 'public')));
    	app.listen(8081, function () {
      console.log('Example app listening on port 8081!')
    });
    