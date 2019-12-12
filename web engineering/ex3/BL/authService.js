let userService = require('./usersService');
let userRepository = require('../repositories/userRepository');

getUserRole = async function(userName, password){
    let userRole = undefined;
    if (userName !== undefined && password !== undefined) {
        let user = await userRepository.getUser(userName, password);
        console.log(`getUserRole: userName:${userName} password:${password}: user:${user}, userRole:${user.role}`);
        if (user !== undefined) {
            userRole = user.role;
            console.log("userRole: " + userRole);
        }
    }
    return userRole;
};

authorizeUser = async function (userName, password) {
    let user = await userRepository.getUser(userName, password);
    return user !== undefined;
};

module.exports.checkAdmin = async function(req, res, next){
    if (await getUserRole(req.query.userName, req.query.password) === "administrator")
        next();
    else
        res.json({error: "not authorized"});
};

module.exports.checkWorker = async (req, res, next) => {
    if (await getUserRole(req.query.userName, req.query.password) === "worker")
        next();
    else
        res.json({error: "not authorized"});
};

module.exports.checkLoggedIn = async (req, res, next) => {
    if (await authorizeUser(req.query.userName, req.query.password))
        next();
    else
        res.json({error: "not logged in"});
}

module.exports.getUserRole = getUserRole;
module.exports.authorizeUser = authorizeUser;