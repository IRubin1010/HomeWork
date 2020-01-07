// remove error message when input is in focus
$(document).ready(function(){
    $(".form-control").focus(function(){
        removeErrMsg()
    });
});

// login button click
$(document).ready(function(){
    $('#btn-login-submit').on("click", async function(){
        let modal = $("#loginModal");
        let userName = modal.find('#user-name').val();
        let password = modal.find('#password').val();
        password = EncryptPassword(password);
        let res = await fetch("/auth/login", {
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
                $("#login-modal-body").prepend( `<p style="color: red" id="errMsg">user name or password is incorrect. please try again</p>`);
            }
        }
        else{
            $('#loginModal').modal('hide');
            location.reload()
        }
    })
});

// empty modal before exit
$(document).ready(function(){
    $('#loginModal').on('hide.bs.modal', function () {
        $(".form-control").val('');
        removeErrMsg()
    })
});

function removeErrMsg(){
    if($("#errMsg").length){
        $("#errMsg").remove();
    }
}

$(document).ready(function(){
    $('#login-modal-forgot-password').on('click', function () {
        $('#loginModal').modal('hide');
        $('#resetPasswordModal').modal('show');
        removeErrMsg()
    })
});

