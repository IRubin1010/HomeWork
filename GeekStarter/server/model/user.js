const mongoose = require("./index");
const bcrypt = require("bcrypt");

const schema = {
    firstName: { type: String, required: true },
    lastName: { type: String, required: true },
    email: { type: String, required: true, unique : true },
    phoneNumber: { type: String, required: true },
    address: { type: String },
    city: { type: String },
    country: { type: String },
    zipCode: { type: String },
    password: { type: String, required: true,
        select: false
    },
};
const collectionName = "users";
const userSchema = mongoose.Schema(schema, {versionKey: false, timestamps: { createdAt: 'created', updatedAt: 'lastUpdate' }});

userSchema.pre('save', async function(next){
    this.password = await bcrypt.hash(this.password, 10);
    next();
});


const User = mongoose.model(collectionName, userSchema);
module.exports = User;