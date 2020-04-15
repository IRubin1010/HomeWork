const User = require('../model/user');
const bcrypt = require("bcrypt");

const validateUserExist = async (user) => {
    try {
        let DBUser = await User.findOne({email: user.email}).exec();
        return !DBUser;
    } catch (err) {
        console.log(`[userService:validateUser] failed to validate user. user={${JSON.stringify(user,null,2)}}, error={${err}}.`);
        return false;
    }
};

const addUser = async (user) => {
    try {
        await User.create({
            firstName: user.firstName,
            lastName: user.lastName,
            email: user.email,
            phoneNumber: user.phoneNumber,
            address: user.address,
            city: user.city,
            country: user.country,
            zipCode: user.zipCode,
            password: user.password
        });
    } catch (err) {
        console.log(`[userService:addUser] failed to create user. user={${JSON.stringify(user,null, 2)}}.`);
        throw err;
    }
};

const getUserByEmailWithPassword = async (email) => {
    try {
        return await User.findOne({email: email}).select('+password').exec();
    } catch (err) {
        console.log(`[userService:getUserByEmail] got an error while getting user from DB. userEmail={${email}}, err={${err}}.`);
        return undefined;
    }
};

const getUserById = async (id) => {
    try {
        return await User.findOne({_id: id}).exec();
    } catch (err) {
        console.log(`[userService:getUserByEmail] got an error while getting user from DB. _id={${id}}, err={${err}}.`);
        return undefined;
    }
};

const validateUserPassword = async (user, password) => {
    return await bcrypt.compare(password, user.password);
};


module.exports = {
    validateUserExist,
    addUser,
    getUserByEmailWithPassword,
    validateUserPassword,
    getUserById
};