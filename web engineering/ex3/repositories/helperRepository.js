let fs = require("fs");
let breadMock = require('../data/products/bread');
let cheeseMock = require('../data/products/cheese');
let fruitMock = require('../data/products/fruits');
let meatMock = require('../data/products/meat');
let userMock = require('../data/users');
let vegetablesMock = require('../data/products/vegetables');
let storeMock = require('../data/stores');
let productRepository = require('../repositories/productRepository');
let userRepository = require('../repositories/userRepository');
let userDb = require('../model')('user');
let productDB = require('../model')('product');

module.exports.initDB = async () => {
    console.log("--------initDB---------");
    try {
        let products = await productRepository.getProducts();
        if (products === undefined || products[0] === undefined) {
            await initProductsDB();
        }

        let users = await userRepository.getUsers();
        if (users[0] === undefined) {
            await this.initUsersDb();
        }
    } catch (err) {
        console.log(err);
    }
    console.log("--------finish initDB---------");
};

async function initProductsDB() {

    let allProducts = breadMock.concat(cheeseMock, fruitMock, meatMock, vegetablesMock);

    let dbProducts = allProducts.map(async product => {
        let productImagePath = `public/images/products/${product.image}`;
        let fileContent = await fs.readFileSync(productImagePath);
        let encodeFile = fileContent.toString('base64');
        let image = {
            contentType: 'image/png',
            data: new Buffer(encodeFile, 'base64')
        };

        let dbProduct = {
            description: product.description,
            price: product.price,
            image: image,
            catagory: product.catagory
        };
        return await productDB.CREATE(dbProduct);
    });

    await Promise.all(dbProducts);
}

module.exports.initUsersDb = async () => {
    console.log("--------initUsersDb---------");
    userMock.forEach(async user => {
        await userDb.CREATE(user);
    });
};


module.exports.initProductsDB = initProductsDB;


// module.exports.initDB = async () => {
//     try {
//         let branches = await this.getAllBranches();
//         if (branches.data.length === 0) {
//             await this.initBranchesDB();
//         }

//         let flowers = await this.getAllFlowers();
//         if (flowers.data.length === 0) {
//             this.initFlowersDB();
//         }

//         let customers = await this.getAllCustomers();
//         if (customers.data.length === 0) {
//             await this.initCustomersDB();
//         }

//         let employees = await this.getAllEmployees();
//         if (employees.data.length === 0) {
//             await this.initEmployeesDB();
//         }
//     } catch(err) {
//         console.log(err);
//     }
// };

// module.exports.initBranchesDB = async () => {
//     branchesMock.forEach(async branch => {
//         await brancheRepository.CREATE(branch);
//     });
// };

// module.exports.initCustomersDB = async () => {
//     let customers = usersMock.filter( (user) => user.role === 'customer');
//     customers.forEach(async customer => {
//         await customerRepository.CREATE(customer);
//     });
// };

// module.exports.initEmployeesDB = async () => {
//     let employees = usersMock.filter( (user) => user.role !== 'customer');
//     employees.forEach(async employee => {
//         await employeeRepository.CREATE(employee);
//     });
// };

// module.exports.initFlowersDB = async () => {
//     flowersMock.forEach(async elem => {
//     let fileContent = fs.readFileSync(elem.src);
//     let encodeFile = fileContent.toString('base64');
//     let src = {
//         contentType: 'image/png',
//         data :new Buffer(encodeFile, 'base64')
//     };

//     let flower = {
//         name: elem.name,
//         price: elem.price,
//         src: src,
//         description: elem.description
//     };
//         await flowerRepository.CREATE(flower);
//     });
// };