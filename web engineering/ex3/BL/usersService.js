let fs = require('fs');
let fsPromise = fs.promises;

module.exports.addUser = async function (user) {
    try{
        let users = await getUsersData();
        users.push(user);
        await putUsersData(users);
        return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.getUsers = async function () {
    try{
        let users = await getUsersData();
        return users;
    }catch (err) {
        console.log(err);
        return [];
    }
};

module.exports.getUser = async function (userName, password) {
    try{
        let users = await getUsersData();
        let user = users.filter(user => {
            return user.userName === userName && user.password === password && user.state === "active"
        })[0];
        return user;
    }catch (err) {
        console.log(err);
        return undefined;
    }
};

module.exports.deleteUser = async function (userToDelete) {
    try{
        let users = await getUsersData();
        let usersToKeep = users.filter(user => {
            return user.userName !== userToDelete.userName || user.password !== userToDelete.password
        });
        await putUsersData(usersToKeep);
        return true;
    }catch (err) {
        console.log(err);
        return false;
    }
};

module.exports.updateUser = async function (updatedUser) {
    try{
        let users = await getUsersData();
        let index = users.findIndex(user => {
            return user.userName === updatedUser.userName && user.password === updatedUser.password
        });
        if(~index){
            users[index] = updatedUser;
            await putUsersData(users);
            return true;
        }else{
            return false;
        }

    }catch (err) {
        console.log(err);
        return false;
    }
};

async function getUsersData() {
    let fileData = await fsPromise.readFile('./data/users.json','utf-8');
    let users = JSON.parse(fileData);
    return users;
}

async function putUsersData(users){
    let usersJson = JSON.stringify(users, null, 2);
    await fsPromise.writeFile('./data/users.json', usersJson, 'utf8');
}