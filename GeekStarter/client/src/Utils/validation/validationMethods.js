const isEmpty = (value) => {
    return value.trim() === "";
};

const isEmail = (email) => {
    const pattern = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
    return  pattern.test(email);
};

const arePasswordMatch = (password, args, state) => {
    return state.password === state.confirmPassword;
};

const minLength = (value, args) => {
    return value.length >= args;
};

const isPhoneNumber = (phoneNumber) => {
  return phoneNumber.length === 9 || phoneNumber.length === 10;
};

export default {
    isEmpty,
    isEmail,
    arePasswordMatch,
    minLength,
    isPhoneNumber
}