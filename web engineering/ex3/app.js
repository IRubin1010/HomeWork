let express = require('express');
let path = require('path');

let indexRouter = require('./routes/index');
let aboutRouter = require('./routes/about');

let app = express();

app.set('view engine', 'ejs');

app.use(express.static(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'views/partials')));

app.use('/', indexRouter);
app.use('/about', aboutRouter);


app.listen(3000, function(){
    console.log(`I am listening to port 3000`)
});

