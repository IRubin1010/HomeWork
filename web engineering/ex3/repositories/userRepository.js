let userDb = require('../model')('user');

module.exports.addUser = async (user) => {
    try {
        let createdUser = await userDb.CREATE(user);
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.getUsers = async () => {

    try {
        let users = await userDb.find({}).exec();
        return users;
    } catch (err) {
        console.log(err);
        return [];
    }
};

module.exports.getUserByUserName = async function (userName) {
    try {
        let user = await userDb.findOne({userName: userName, state: "active"}).exec();

        return user;
    } catch (err) {
        console.log(err);
        return undefined;
    }
};

module.exports.findById = async function (id) {
    try {
        let user = await userDb.findById(id).exec();
        return user;
    } catch (err) {
        console.log(err);
        return undefined;
    }
};

module.exports.deleteUser = async (userToDelete) => {
    try {
        await userDb.findOneAndDelete({userName: userToDelete.userName}).exec();
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.updateUser = async (user) => {
    try {
        let fieldsToUpdate = {role: user.role, mail: user.mail, state: user.state};
        await userDb.findOneAndUpdate({
            userName: user.userName,
            password: user.password
        }, fieldsToUpdate, {new: true}).exec();
        return true;
    } catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.validetUser = async function (userToVlidate) {
    try {
        let user = await userDb.findOne({username: userToVlidate.userName}).exec();
        return user;
    } catch (err) {
        console.log(err);
        return false;
    }
};
