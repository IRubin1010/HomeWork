// remove error message when input is in focus
$(document).ready(function(){
    $(".form-control").focus(function(){
        removeErrMsg()
    });
});

// login button click
$(document).ready(function(){
    $('#btn-reset-password-submit').on("click", async function(){
        let modal = $("#resetPasswordModal");
        let email = modal.find('#email').val();
        console.log(email);
        let res = await fetch("/resetPassword/request", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: email
            })
        });
        if(res.status !== 200){
            if(!$("#errMsg").length){
                $("#reset-password-modal-body").prepend( `<p style="color: red" id="errMsg">user name or password is incorrect. please try again</p>`);
            }
        }
        else{
            $("#reset-password-modal-content").replaceWith( `<p class="modal-body" style="color: #305c65; font-size: 24px; padding: 30px" id="errMsg">We have sent you an Email with reset password link. <br> please check the email for resetting the password</p>`);
        }
    })
});

// empty modal before exit
$(document).ready(function(){
    $('#resetPasswordModal').on('hide.bs.modal', function () {
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
    $('#reset-password-password').change(validatePasswords);
    $('#reset-password-confirm').change(validatePasswords);

});

$(document).ready(function(){
    $("#reset-password-form").submit(async function (e) {
        e.preventDefault();
        let urlParams = new URLSearchParams(window.location.search);
        let user = urlParams.get('user');
        let token = urlParams.get('token');
        let password = $('#reset-password-confirm').val();
        password = EncryptPassword(password);

        let res = await fetch("/resetPassword", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                user: user,
                token: token,
                password: password
            })
        });
        if(res.status !== 200){
            if(!$("#errMsg").length){
                $("#reset-password-form").prepend( `<p style="color: red" id="errMsg">something went wrong, please try again</p>`);
            }
        }
        else{
            $("#reset-password-form").prepend( `<p style="color: red" id="errMsg">your password has benn change</p>`);

            await setTimeout(async function () {
                await fetch("/auth/login", {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        userName : user,
                        password : password
                    })
                });
                window.location = "/"
            }, 1500);
        }
    });

});

function validatePasswords(){
    let password = $('#reset-password-password').val();
    let confirmPassword = $('#reset-password-confirm').val();
    if(password !== confirmPassword){
        $("#reset-password-confirm")[0].setCustomValidity("Passwords Don't Match")
    }else{
        $("#reset-password-confirm")[0].setCustomValidity("")
    }
}

