// logout clicking
$(document).ready(async function () {
    $('#logout').on("click", async function () {
        await fetch("/auth/logout");
        window.location = "/"
    })
});

$(document).ready(async function () {
    let userName;
    let res = await fetch("/auth/userName");
    let resJson = await res.json();
    if (res.status !== 200) {
        userName = undefined;
    }else{
        userName =  resJson.userName;
    }
    if(userName){
        $('#logout-btn').before(`<h5 class="header-user-name">${userName}</h5>`)
    }
});


