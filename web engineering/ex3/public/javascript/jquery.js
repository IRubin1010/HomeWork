// keeps the Query String when click on an href
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

// logout clicking
$(document).ready(async function () {
    $('#logout').on("click", function () {
        let url = window.location.href.toString();
        if (url.indexOf("?") > 0) {
            let clean_url = url.substring(0, url.indexOf("?"));
            window.history.replaceState({}, document.title, clean_url);
            window.location = clean_url;
        }
    })
});
