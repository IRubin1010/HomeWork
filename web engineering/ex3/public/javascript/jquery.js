$(document).ready(async function () {
    let hash = location.hash;
    if (hash !== "") {
        let replacedHash = hash.replace('#', '');
        if(replacedHash === "stores"){
            await loadStores();
            return;
        }
        $("#middle-page").load(replacedHash + ".ejs");

    }
});

$(document).ready(function () {
    $('a[href="#about"]').on("click", async function () {
            let res = await fetch("/about");
            let resJson = await res.json();
            let page = resJson.page;
            $("#middle-page").load(page);
        }
    );
});

$(document).ready(function () {
    $('a[href="#stores"]').on("click", loadStores);
});


async function loadStores() {
    let res = await fetch("/stores");
    let resJson = await res.json();
    let page = resJson.page;
    let stores = resJson.stores;
    $("#middle-page").load(page);
    let template = await jQuery.get('templates/store.ejs');
    $.tmpl(template, stores).appendTo("#stores-cards");
}


$(document).ready(async function () {
    let productsCategory = await fetch("/productsCategory");
    let productsCategoryJson = await productsCategory.json();
    let template = await jQuery.get('templates/productsCategory.ejs');
    $.tmpl(template, productsCategoryJson).appendTo("#products-category-cards");
});


// $( "#middle-page" ).load( "<%= page %>" );