let userRepository = require('../repositories/userRepository');

module.exports.authenticate = function(req, res, next){
    if(req.isAuthenticated()){
        next()
    }
    else{
        res.send(401)
    }
};

module.exports.checkAdminOrWorker = async (req, res, next) => {
    if(req.user.role === "worker" || "administrator"){
        next();
    }
    else
        res.json({error: "not authorized"});
};

module.exports.checkAdmin = async function(req, res, next){
    if(req.user.role === "administrator"){
        next();
    }
    else
        res.json({error: "not authorized"});
};

module.exports.checkWorker = async (req, res, next) => {
    if(req.user.role === "worker"){
        next();
    }
    else
        res.json({error: "not authorized"});
};