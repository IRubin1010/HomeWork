let users = require('../data/users');


let state = {
    Active : 'active',
    Deleted : 'deleted'
}

module.exports.getUser = function(userName, password){
    let user = users.filter(user => {
        return user.userName === userName && user.password === password && user.state === state.Active
    })[0];
    return user;
};