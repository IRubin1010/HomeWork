export const start = (action) => {
    return {
        type: action
    }
};

export const success = (action, data) => {
    return {
        type: action,
        ...data
    }
};

export const fail = (action, err) => {
    return {
        type: action,
        error: err
    }
};