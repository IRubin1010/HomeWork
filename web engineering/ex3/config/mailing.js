let nodemailer = require('nodemailer');
module.exports = nodemailer.createTransport({
    host: 'smtp.gmail.com',
    port: 587,
    secure: false,
    requireTLS: true,
    auth: {
        user: 'superstore.israel@gmail.com',
        pass: 'superstore12345'
    }
});