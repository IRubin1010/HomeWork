let path = require("path");
let express = require('express');
let app = express();
let Student = require("./Model/student");

app.set('view engine', 'ejs');

app.use(express.static(path.join(__dirname, 'public')));

app.get('/', function (req, res) {
    let students = [
      new Student("Itzik", "Yeret", "0504182088", "yeret82088@gmail.com", "computers"),
      new Student("Meir", "Shimon", "0504182088", "nthr120@gmail.com", "computers"),
      new Student("Avi", "Margali", "0527620748", "avimargali@gmail.com", "computers")
  ]
  res.render('pages/index', { students: students});
  //res.render('index');
});

app.get('/about', function(req, res) {
  res.render('pages/about');
});

app.listen(8081, function () {
  console.log('Example app listening on port 8081!')
});
