let express = require('express');
let path = require('path');
let bodyParser = require('body-parser');
let logger = require('morgan');
let passport = require('passport');
let session = require('express-session');

let passportConfig = require('./config/passport');
passportConfig.initPassport(passport);

//require routs
let indexRouter = require('./routes/index');
let aboutRouter = require('./routes/about');
let storesRouter = require('./routes/stores');
let authRouter = require('./routes/auth');
let productsCategoryRouter = require('./routes/productsCategory');
let productsRouter = require('./routes/products');
let usersRouter = require('./routes/users');


let app = express();

// set view engine to ejs
app.set('view engine', 'ejs');

// set body-parser
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({     // to support URL-encoded bodies
    extended: true
}));

// set session
app.use(
    session({
        secret: 'theBestSecretEver',
        cookie: {
            expires: false,
            httpOnly: false
        },
        resave: true,
        saveUninitialized: true
    })
);

// passport
app.use(passport.initialize());
app.use(passport.session());

// set morgan
app.use(logger('dev'));


// set folders
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'views/partials')));
app.use(express.static(path.join(__dirname, 'node_modules')));

// set routs
app.use('/', indexRouter);
app.use('/about', aboutRouter);
app.use('/productsCategory', productsCategoryRouter);
app.use('/stores', storesRouter);
app.use('/auth', authRouter);
app.use('/products', productsRouter);
app.use('/users', usersRouter);

module.exports = app;

// app.listen(3000, function(){
//     console.log(`I am listening to port 3000`)
// });

