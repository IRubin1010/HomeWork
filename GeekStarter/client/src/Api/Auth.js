import axios from "./Axios";

export const loginApi = async (email, password) => {
    return await axios.post('/auth/login', {
        email: email,
        password: password
    });
};

export const signUpApi = async (user) => {
    return await axios.post('/auth/register', {user: user});
};

export const logoutApi = async () => {
    return await axios.post('/auth/logout');
};
