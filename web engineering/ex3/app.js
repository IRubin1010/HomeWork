let express = require('express');
let path = require('path');

//require routs
let indexRouter = require('./routes/index');
let aboutRouter = require('./routes/about');
let productsCategory = require('./routes/productsCategory');


let app = express();

// set view engine to ejs
app.set('view engine', 'ejs');

// set folders
app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'views/partials')));
app.use(express.static(path.join(__dirname, 'data')));

// set routs
app.use('/', indexRouter);
app.use('/about', aboutRouter);
app.use('/productsCategory', productsCategory);


app.listen(3000, function(){
    console.log(`I am listening to port 3000`)
});

