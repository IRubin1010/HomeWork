let userService = require('./usersService');

module.exports.getUserRole = async function(userName, password){
    let userRole = undefined;
    if (userName !== undefined && password !== undefined) {
        let user = await userService.getUser(userName, password);
        if (user !== undefined) {
            userRole = user.role;
        }
    }
    return userRole;
};

module.exports.authorizeUser = async function (userName, password) {
    let user = await userService.getUser(userName, password);
    return user !== undefined;
};