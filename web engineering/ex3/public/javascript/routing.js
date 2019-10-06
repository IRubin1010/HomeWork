// get the page based on the hash or the first page
$(document).ready(async function () {
    let hash = location.hash;
    if (hash !== "") {
        let replacedHash = hash.replace('#', '');
        if (replacedHash === "stores") {
            await loadStores();
            return;
        }
        if (replacedHash === "products") {
            await loadProducts();
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
    $('a[href="#stores"]').on("click", async function(){
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
    setTimeout(function () {
        $.tmpl(template, stores).appendTo("#stores-cards");
        $(".cover").hide();
    }, 1500);
}

// get products page by clicking on products
$(document).ready(function(){
    $('a[href="#products"]').on("click", loadProducts);
})


// get products content
async function loadProducts() {
    $(".cover").show();
    let res = await fetch("/products");
    let resJson = await res.json();
    let bread = resJson.bread;
    let cheese = resJson.cheese;
    let middlePage = resJson.middlePage;
    $("#middle-page").load(middlePage);
    let template = await jQuery.get('templates/productsCatalog.ejs');
    setTimeout(function () {
        $.tmpl(template, cheese).appendTo("#products-Vegetables");
        $.tmpl(template, bread).appendTo("#products-Bread");
        $.tmpl(template, cheese).appendTo("#products-Fruits");
        $.tmpl(template, cheese).appendTo("#products-Meat");
        $.tmpl(template, cheese).appendTo("#products-Cheese");
        $(".cover").hide();
    }, 1500);
}