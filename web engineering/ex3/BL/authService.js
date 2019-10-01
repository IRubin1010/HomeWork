let users = require('../data/users');

module.exports.getUser = function(userName, password){
    let user = users.filter(user => {
        return user.userName === userName && user.password === password
    })[0];
    return user;
};