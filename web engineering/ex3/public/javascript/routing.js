// get the page based on the hash or the first page
$(document).ready(async function () {
    let hash = location.hash;
    if (hash !== "") {
        let replacedHash = hash.replace('#', '');
        if (replacedHash === "stores") {
            await loadStores();
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
            let res = await fetch("/about");
            let resJson = await res.json();
            let middlePage = resJson.middlePage;
            $("#middle-page").load(middlePage);
        }
    );
});

// get stores page by clicking on stores
$(document).ready(function () {
    $('a[href="#stores"]').on("click", loadStores);
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


