const debug = require("debug")("mongo:model-product");
const mongoose = require("mongoose");
let Schema = mongoose.Schema;

module.exports = function(db) {
    let productSchema = Schema(
        {
            description: { type: String, required: true },
            price: { type: String, required: true },
            image:  {
                data: Buffer, 
                contentType: String 
            },
            catagory: {type: String, enum: ['bread', 'cheese', 'fruits', 'meat', 'vegetables'] },
            lastUpdate: Date,
            created: Date
        },
        { versionKey: false }
    );

    productSchema.statics.CREATE = async function(product) {

        return this.create(
            {
                description: product.description,
                price: product.price,
                image: product.image,
                catagory: product.catagory
            }
        );
    };

    productSchema.pre('save', function(next){
            let date = new Date();
            this.lastUpdate = date;
            if (!this.created) {
                this.created = date;
            }
            next();
  });

  db.model("product", productSchema);
  debug("Product model created successfully");
};