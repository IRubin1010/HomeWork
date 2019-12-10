	// reference the http module so we can create a webserver
    let http = require("http");
    let path = require("path");
    let express = require('express');
    let app = express();
    app.use(express.static(path.join(__dirname, 'public')));

    app.get('/OrderConfirmation', function (req, res) {
        let url=req.query;
        let flower = url.flowerList;
        let amount = url.amount;
        let adress = url.adress;
        let PackingColor = url.PackingColor;
        res.send({flower:flower, amount:amount,adress:adress,PackingColor:PackingColor});
    });
    app.listen(8080, function () {
      console.log('listening on port 8080!')
    });
    

