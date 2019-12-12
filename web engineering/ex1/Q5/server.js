	// reference the http module so we can create a webserver
    let http = require("http");
    let path = require("path");
    let express = require('express');
    let app = express();
    app.use(express.static(path.join(__dirname, 'public')));

    app.get('/user', function (req, res) {
        console.log(req.originalUrl);
        console.log(req.protocol);
        console.log(req.hostname);
        console.log(req.ip);
        console.log(req.path);
        console.log(req.query);
        let Name = req.query.name;
        let Password = req.query.Password;
        if ((Name == "Meir" || Name == "Yizchak" || Name == "Dan") && Password == "123456") {
            res.send("Welcome " + Name)
        } else {
            res.send("Name or password are not correct please try again");
        }
    });
    app.listen(8080, function () {
      console.log('Example app listening on port 8080!')
    });
    

