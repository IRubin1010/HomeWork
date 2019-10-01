$(document).ready(async function () {
    let hash = location.hash;
    if (hash !== "") {
        let replacedHash = hash.replace('#', '');
        if (replacedHash === "stores") {
            await loadStores();
            return;
        }
        $("#middle-page").load(replacedHash + ".ejs");

    }
});

$(document).ready(function () {
    $("a[rel~='keep-params']").on("click", function (e) {
            e.preventDefault();
            let params = window.location.search;
            let dest = $(this).attr('href') + params;

            // a short timeout has helped overcome browser bugs
            window.setTimeout(function () {
                window.location.href = dest;
            }, 100);
        }
    );
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

$(document).ready(async function () {
    $('#logout').on("click", function(){
        let url = window.location.href.toString();
        if (url.indexOf("?") > 0) {
            let clean_url = url.substring(0, url.indexOf("?"));
            window.history.replaceState({}, document.title, clean_url);
            window.location = clean_url;
        }
    })
});


// $( "#middle-page" ).load( "<%= page %>" );