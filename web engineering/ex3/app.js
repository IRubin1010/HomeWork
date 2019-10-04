let express = require('express');
let path = require('path');
let bodyParser = require('body-parser');

//require routs
let indexRouter = require('./routes/index');
let aboutRouter = require('./routes/about');
let storesRouter = require('./routes/stores');
let authRouter = require('./routes/auth');
let productsCategoryRouter = require('./routes/productsCategory');


let app = express();

// set view engine to ejs
app.set('view engine', 'ejs');

// set body-parser
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({     // to support URL-encoded bodies
    extended: true
}));

// set folders
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'views/partials')));

// set routs
app.use('/', indexRouter);
app.use('/about', aboutRouter);
app.use('/productsCategory', productsCategoryRouter);
app.use('/stores', storesRouter);
app.use('/auth', authRouter);


app.listen(3000, function(){
    console.log(`I am listening to port 3000`)
});

