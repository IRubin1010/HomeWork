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
        if(replacedHash === "administration"){
            await loadUsers();
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

// get products content
async function loadProducts() {
    $(".cover").show();

    let userRole = await getUserRole();
    if(userRole === undefined){
        $(".cover").hide();
        return;
    }

    let res = await fetch("/products");
    let resJson = await res.json();
    let bread = resJson.bread;
    let cheese = resJson.cheese;
    let middlePage = resJson.middlePage;
    $("#middle-page").load(middlePage);
    let template = await jQuery.get('templates/productsCatalog.ejs');
    await setTimeout(function () {
        $.tmpl(template, cheese).appendTo("#products-Vegetables");
        $.tmpl(template, bread).appendTo("#products-Bread");
        $.tmpl(template, cheese).appendTo("#products-Fruits");
        $.tmpl(template, cheese).appendTo("#products-Meat");
        $.tmpl(template, cheese).appendTo("#products-Cheese");
        setTimeout(function(){
            scrollToHash();
        }, 50);
        $(".cover").hide();
    }, 1500);
}

$(document).ready(function () {
    $('a[href="#products-vegetables"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if(window.location.hash.startsWith("#products")){
            scrollToHash();
        }else{
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-fruits"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if(window.location.hash.startsWith("#products")){
            scrollToHash();
        }else{
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-bread"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if(window.location.hash.startsWith("#products")){
            scrollToHash();
        }else{
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-meat"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if(window.location.hash.startsWith("#products")){
            scrollToHash();
        }else{
            await loadProducts();
        }
    });
});

$(document).ready(function () {
    $('a[href="#products-cheese"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        if(window.location.hash.startsWith("#products")){
            scrollToHash();
        }else{
            await loadProducts();
        }
    });
});

function scrollToHash() {
    let id = window.location.hash.replace('#', '');
    document.getElementById(id).scrollIntoView();
}

$(document).ready(async function () {
    $('a[href="#administration"]').on("click", async function () {
        $('.navbar-collapse').collapse('hide');
        await loadUsers();
    });
});

async function loadUsers() {
    $(".cover").show();
    let userRole = await getUserRole();
    let resJson;
    if(userRole === undefined || userRole === "client"){
        $(".cover").hide();
        return;
    }else if(userRole === "administrator"){
        let res = await fetch("/users/administratorData");
        resJson = await res.json();
    }else if(userRole === "worker"){
        let res = await fetch("/users/workerData");
        resJson = await res.json();
    }
    let users = resJson.users;
    let middlePage = resJson.middlePage;
    let templatePage = resJson.template;

    $("#middle-page").load(middlePage);

    let template = await jQuery.get(`templates/${templatePage}`);
    let compiledTemplate = ejs.compile(template, {});

    let data = {
        users : users,
        userRole: userRole
    };

    let html = compiledTemplate(data);
    await setTimeout(function () {
        $("#users").html(html);
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
            userName : userName,
            password : password
        })
    });
    let resJson = await res.json();
    if(res.status !== 200){
        return undefined;
    }
    return resJson.userRole;
}





