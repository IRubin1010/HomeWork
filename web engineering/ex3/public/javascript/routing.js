// get the page based on the hash or the first page
$(document).ready(async function () {
    let hash = location.hash;
    if (hash !== "") {
        let replacedHash = hash.replace('#', '');
        if (replacedHash === "stores") {
            await loadStores();
            return;
        }
        if (replacedHash.startsWith("products")) {
            await loadProducts();
            return;
        }
        if (replacedHash === "Manage-People") {
            await loadUsers();
            return;
        }
        if (replacedHash === "Manage-Products") {
            await loadManageProducts();
            return;
        }
        $("#middle-page").load(replacedHash + ".ejs");
    } else {
        $(".cover").show();
        let productsCategory = await fetch("/productsCategory");
        let productsCategoryJson = await productsCategory.json();
        let template = await jQuery.get('templates/productsCategory.ejs');
        setTimeout(function () {
            $.tmpl(template, productsCategoryJson).appendTo("#products-category-cards");
            $(".cover").hide();
        }, 1500);
    }
});

// get about page by clicking on about
$(document).ready(function () {
    $('a[href="#about"]').on("click", async function () {
            $('.navbar-collapse').collapse('hide');
            let res = await fetch("/about");
            let resJson = await res.json();
            let middlePage = resJson.middlePage;
            $("#middle-page").load(middlePage);
        }
    );
});

// get stores page by clicking on stores
$(document).ready(function () {
    $('a[href="#stores"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        await loadStores();
    });
});

// get stores content
async function loadStores() {
    $(".cover").show();
    let res = await fetch("/stores");
    let resJson = await res.json();
    let stores = resJson.stores;
    let middlePage = resJson.middlePage;
    $("#middle-page").load(middlePage);
    let template = await jQuery.get('templates/store.ejs');
    await setTimeout(function () {
        $.tmpl(template, stores).appendTo("#stores-cards");
        $(".cover").hide();
    }, 1500);
}

// get products page by clicking on products
$(document).ready(function () {
    $('a[href="#products"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        await loadProducts();
    });
});

$(document).ready(function () {
    $('body').on('click', 'div[id=products]', async function () {
        $('.navbar-collapse').collapse('hide');
        if (window.location.hash.startsWith("#products")) {
            scrollToHash();
        } else {
            await loadProducts();
        }
        ;
    });
});


// get products content
async function loadProducts() {
    $(".cover").show();

    let userRole = await getUserRole();
    if (userRole === undefined) {
        $(".cover").hide();
        return;
    }

    let res = await fetch("/products" + window.location.search);
    let resJson = await res.json();

    let middlePage = resJson.middlePage;
    let templatePage = resJson.template;
    $("#middle-page").load(middlePage);

    let template = await jQuery.get(`templates/${templatePage}`);
    let compiledTemplate = ejs.compile(template, {});

    let bread = resJson.bread;
    let cheese = resJson.cheese;
    let vegetables = resJson.vegetables;
    let fruits = resJson.fruits;
    let meat = resJson.meat;

    let data = {
        data: [
            {
                category: "Vegetables",
                products: vegetables
            },
            {
                category: "Fruits",
                products: fruits
            },
            {
                category: "Bread",
                products: bread
            },
            {
                category: "Meat",
                products: meat
            },
            {
                category: "Cheese",
                products: cheese
            }
        ]
    };

    let html = compiledTemplate(data);

    await setTimeout(function () {
        $("#products-cards").html(html);
        setTimeout(function () {
            scrollToHash();
        }, 100);
        $(".cover").hide();
    }, 1500);
}

$(document).ready(function () {
    $('a[href="#products-vegetables"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if (window.location.hash.startsWith("#products")) {
            scrollToHash();
        } else {
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-fruits"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if (window.location.hash.startsWith("#products")) {
            scrollToHash();
        } else {
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-bread"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if (window.location.hash.startsWith("#products")) {
            scrollToHash();
        } else {
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-meat"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if (window.location.hash.startsWith("#products")) {
            scrollToHash();
        } else {
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-cheese"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if (window.location.hash.startsWith("#products")) {
            scrollToHash();
        } else {
            await loadProducts();
        }
    });
});

function scrollToHash() {
    let id = window.location.hash.replace('#', '');
    document.getElementById(id).scrollIntoView();
}

$(document).ready(async function () {
    $('a[href="#Manage-People"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        console.log("manage people")
        await loadUsers();
    });
});

async function loadUsers() {
    $(".cover").show();
    let userRole = await getUserRole();
    let resJson;
    if (userRole === undefined || userRole === "client") {
        $(".cover").hide();
        return;
    } else if (userRole === "administrator") {
        let res = await fetch("/users/administratorData" + window.location.search);
        resJson = await res.json();
    } else if (userRole === "worker") {
        let res = await fetch("/users/workerData" + window.location.search);
        resJson = await res.json();
    }
    let users = resJson.users;
    let middlePage = resJson.middlePage;
    let templatePage = resJson.template;

    $("#middle-page").load(middlePage);

    let template = await jQuery.get(`templates/${templatePage}`);
    let compiledTemplate = ejs.compile(template, {});

    let data = {
        users: users,
        userRole: userRole
    };

    let html = compiledTemplate(data);
    await setTimeout(function () {
        $("#users").html(html);
        $(".cover").hide();
    }, 1500);
}

$(document).ready(async function () {
    $('a[href="#Manage-Products"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        console.log("Manage-Products")
        await loadManageProducts();
    });
});

async function loadManageProducts() {
    $(".cover").show();
    let userRole = await getUserRole();
    let resJson;
    if (userRole === undefined || userRole === "client") {
        $(".cover").hide();
        return;
    } else {
        let res = await fetch("/products/productsData" + window.location.search);
        resJson = await res.json();
    }
    let products = resJson.products;
    let middlePage = resJson.middlePage;
    let templatePage = resJson.template;

    $("#middle-page").load(middlePage);

    let template = await jQuery.get(`templates/${templatePage}`);
    let compiledTemplate = ejs.compile(template, {});

    console.log(products)
    let data = {
        products: products,
    };

    let html = compiledTemplate(data);
    await setTimeout(function () {
        $("#productsManage").html(html);
        $(".cover").hide();
    }, 1500);
}

async function getUserRole() {
    let search = new URLSearchParams(window.location.search);
    let userName = search.get("userName");
    let password = search.get("password");
    let res = await fetch("/auth/userRole", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            userName: userName,
            password: password
        })
    });
    let resJson = await res.json();
    if (res.status !== 200) {
        return undefined;
    }
    return resJson.userRole;
}





