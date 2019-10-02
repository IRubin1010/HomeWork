// remove error message when input is in focus
$(document).ready(function(){
    $(".form-control").focus(function(){
        removeErrMsg()
    });
});

// login button click
$(document).ready(function(){
    $('#btn-login-submit').on("click", async function(){
        let modal = $("#exampleModal");
        let userName = modal.find('#user-name').val();
        let password = modal.find('#password').val();
        console.log(`user name: ${userName}, password: ${password}`);
        let res = await fetch("/auth", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userName : userName,
                password : password
            })
        });
        if(res.status !== 200){
            if(!$("#errMsg").length){
                $(".modal-body").prepend( `<p style="color: red" id="errMsg">user name or password is incorrect. please try again</p>`);
            }
        }
        else{
            let hash = window.location.hash;
            let path = location.pathname;
            let url = path + `?userName=${userName}&password=${password}` + hash;
            location = url;
            $('#exampleModal').modal('hide');
        }
    })
});

// empty modal before exit
$(document).ready(function(){
    $('#exampleModal').on('hide.bs.modal', function () {
        $(".form-control").val('');
        removeErrMsg()
    })
});

function removeErrMsg(){
    if($("#errMsg").length){
        $("#errMsg").remove();
    }
}