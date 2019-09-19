let express = require('express');
let path = require('path');

let app = express();

app.set('view engine', 'ejs');

app.use(express.static(path.join(__dirname, 'public')));

app.get('/', function(req, res){
    res.render(`pages/index`)
});

app.listen(3000, function(){
    console.log(`I am listening to port 3000`)
});

