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
    // try{
    //     let returnUser = null;
    //     let user = await userDb.find({userName: userName, password: password, state: "active"},(err, user) => {
    //         console.log(err);
    //         if (!err) {
    //             returnUser = user;
    //             console.log(`call Get user functaion for user:  ${user}`);
    //         }else{
    //             console.log(err);
    //         }
    //     });
    //     return returnUser;
    // }catch (err) {
    //     console.log(err);
    //     return undefined;
    // }
    try{
        let user = await userDb.find({userName: userName, password: password, state: "active"}).exec();
        console.log(user);
        return user;
    }catch (err) {
        console.log(err);
        return undefined;
    }
};

module.exports.deleteUser = async (userToDelete) => {
    try {
        console.log(userToDelete);
        let employee = await userDb.findOneAndDelete({userName: userToDelete.userName, password: userToDelete.password},err =>{
            console.log(err);
        });
        !!employee ? console.log(`Employee: ${employee} \n successfully deleted !!`)
        : console.log(`ERROR: Employee with name: ${userToDelete.userName} not found !!`);
    } catch (error) {
        console.log(error);
        return false
    }
    return true;
};
