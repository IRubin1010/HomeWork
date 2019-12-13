let userDb = require('../model')('user');

module.exports.adduser = async (user) => {
    try{
    let createdUser = await userDb.CREATE(user);
    console.log(`A new employee created: ${createdUser}`);
    return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.getUsers = async () => {

    try {
        let users = await userDb.find({}).exec();
        return users;
    }catch (err) {
        console.log(err);
        return [];
    }
};


module.exports.getUser = async function (userName, password) {
    try{
        let user = await userDb.find({userName: userName, password: password, state: "active"}).exec();
        console.log(user);
        return user[0]._doc;
    }catch (err) {
        console.log(err);
        return undefined;
    }
};

module.exports.deleteUser = async (userToDelete) => {
    try {
        await userDb.findOneAndDelete({userName: userToDelete.userName, password: userToDelete.password}).exec();
            return true;
        }catch (err) {
            console.log(err);
            return false;
        }
};

module.exports.updateUser = async (user) => {
    try{
    let fieldsToUpdate = { role: user.role, mail: user.mail , state: user.state  };
    await userDb.findOneAndUpdate({ userName: user.userName , password: user.password }, fieldsToUpdate, { new: true });
    return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.validetUser = async function (userToVlidate) {
    try {
        let user =  await userDb.find({username: userToVlidate.userName, password: userToVlidate.password}).exec();
        return user[0];
    }catch (err) {
        console.log(err);
        return false;
    }
};
