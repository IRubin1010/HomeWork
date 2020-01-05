const debug = require("debug")("mongo:model-users");
const mongoose = require("mongoose");
let Schema = mongoose.Schema;

module.exports = function(db) {
    let userSchema = Schema(
        {
            userName: { type: String, required: true },
            password: { type: String, required: true }, //, maxlength: [8, 'Too long password'], minlength: [4, 'Too short password']
            role: { type: String, enum: ['administrator', 'worker', 'client'] },
            mail: {type: String},
            state: {type: String, enum: ['active', 'deleted'] },
            lastUpdate: Date,
            created: Date
        },
        { versionKey: false }
    );

    userSchema.statics.CREATE = async function(user) {
        return this.create(
            {
                userName: user.userName,
                password: user.password,
                role: user.role,
                mail: user.mail,
                state: user.state
            }
        );
    };

    userSchema.pre('save', function(next){
            let date = new Date();
            this.lastUpdate = date;
            if (!this.created) {
                this.created = date;
            }
            next();
  });

  db.model("user", userSchema);
  debug("User model created successfully");
};