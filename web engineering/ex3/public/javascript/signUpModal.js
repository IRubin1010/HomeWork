// remove error message when input is in focus
$(document).ready(function(){
    $(".form-control").focus(function(){
        removeErrMsg()
    });
});

// login button click
$(document).ready(function(){
    $('#btn-sign-up-submit').on("click", async function(){
        let modal = $("#signUpModal");
        console.log(modal);
        let userName = modal.find('#user-name').val();
        let password = modal.find('#password').val();

        password = EncryptPassword(password);
        //let d = DecryptPassword(e);

        let mail = modal.find('#mail').val();
        // password = CryptoJS.MD5(password);
        let user = {
            userName: userName,
            password: password,
            mail: mail,
            role: "client",
            state: "active"
        };
        let res = await fetch("/users/addClient", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                user: user
            })
        });
        if(res.status !== 200){
            if(!$("#errMsg").length){
                $("#signup-modal-body").prepend( `<p style="color: red" id="errMsg">user name or password is incorrect. please try again</p>`);
            }
        }
        else{
            $('#signUpModal').modal('hide');
            await fetch("/auth/login", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    userName : userName,
                    password : password
                })
            });
            location.reload()
        }
    })
});

// empty modal before exit
$(document).ready(function(){
    $('#signUpModal').on('hide.bs.modal', function () {
        $(".form-control").val('');
        removeErrMsg()
    })
});

function removeErrMsg(){
    if($("#errMsg").length){
        $("#errMsg").remove();
    }
}