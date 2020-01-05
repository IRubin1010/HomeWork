const NodeRSA = require('node-rsa');
const key = new NodeRSA(`-----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQCH9xeqgb77DlvbymFmHTmIZsNul3Jt6fS9bcn/N52eSORI5li5
nqAJVKq+NdmW7OG8xAeyVvfSGDzH6s+MeNqA7az6m1YvJa2oaufMJRJzoed8Fsou
iY7i2ZewBxLXf1AwypoK9rnRt9hGeJijOGhr9YjjHB+VnyWyBln0Kq1ASwIDAQAB
AoGARK5DbSTnJQiGzEq50ow2sLlARVAJRI5my313CQ299+PYNR7ueK0xKCV1rmmj
RULZcLIRNTwLKTyHD3GEb+/oZ25Rjcs5y1pdyRGh6gLDq88ACfDDCJIHF2K7mFCV
jiEJvZhhEUZcRaXXsdJpMXTMPftKGhifqRC/CezApF8PGykCQQD2dX6fKfiCccKH
rjshMVhygCYollp2O0ZEoRGKXcrtb9wPvrI6f2vvsNKsYmQs8qGcubxltzjOT+T+
YM9pZnIdAkEAjTqPqNCA701ZEx9+X5pAlZiWYOvY7HCrQLCI6SfJEGttQA9SlZEX
g/w+Owhx5ZgWfUb4eq4Z1GI/6e0eKzbvhwJBAMGnCqo3iUu95VNFJLLtGglGBjWo
BkaWRp1QTf8BuZydYzV/6n0qd/4rWy4WVY43y6LhElZ+BAWgI1d5bB/uXkUCQG4V
4Nd5N5fRVgaW/P3ukjtJxqZkESI0rPju4rnDnnHjGzTc/MXDZG4oWCXR7l5GT/l1
MckHHvEzaJiikWqkFs8CQEUOMkjXmnAhsN/Z4k4tu4IAkS89bOWWnndbUlHuGmGZ
VXqOM75O+eR7eElo6zD/kgDN5BmwDB53574r0D6jTS4=
-----END RSA PRIVATE KEY-----`);
//key.generateKeyPair(2048,65537);
// console.log(key.exportKey("pkcs8-public-pem"));
// console.log(key.exportKey("pkcs8-private-pem"));
// const text = 'secretKeyForUdAndAvi';
// const encrypted = key.encrypt(text, 'base64');
// console.log('encrypted: ', encrypted);
// const decrypted = key.decrypt(encrypted, 'utf8');
// console.log('decrypted: ', decrypted);
module.exports = {
    EncryptPassword :function (pass){
        return key.encrypt(pass, 'base64');
    },
    DecryptPassword : function (pass){
        return key.decrypt(pass, 'utf8');
    }
};

