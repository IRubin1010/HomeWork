$(document).ready(function () {
    let hash = location.hash;
    if (hash !== "") {
        console.log(hash);
        let replacedHash = hash.replace('#', '');
        console.log(replacedHash);
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


$(document).ready(async function () {
    let productsCategory = await fetch("/productsCategory");
    let productsCategoryJson = await productsCategory.json();
    console.log("got data");
    console.log(productsCategoryJson);
    let template = await $.get('templates/productsCategory.ejs');
    console.log("done");
    console.log(template);
    $.tmpl(template, productsCategoryJson).appendTo("#products-category-cards");
});

// $( "#middle-page" ).load( "<%= page %>" );