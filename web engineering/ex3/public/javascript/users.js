async function addUserModal() {
    $('#addUserModal').modal('show');
}

$(document).ready(function () {
    $('#btn-add-user').on("click", async function () {
        let modal = $("#addUserModal");
        let userName = modal.find('#add-user-name').val();
        let password = modal.find('#add-user-password').val();
        let mail = modal.find('#add-user-mail').val();
        let role = modal.find('#add-user-role').val();

        let user = {
            userName : userName,
            password: password,
            mail: mail,
            role: role,
            state: "active"
        };

        let res = await fetch("/users/add", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                user: user
            })
        });

        if (res.status !== 200) {
            if (!$("#errMsg").length) {
                $(".modal-body").prepend(`<p style="color: red" id="errMsg">an error has occurred please try again</p>`);
            }
        } else {
            $('#exampleModal').modal('hide');
            window.location.reload();
        }
    })
});

// empty modal before exit
$(document).ready(function () {
    $('#addUserModal').on('hide.bs.modal', function () {
        $(".form-control").val('');
        $("#add-user-role").val('client');
        removeErrMsg()
    })
});

async function deleteUser(caller) {

    let tableRow = $(caller).closest('tr');
    let user = getUserFromRow(tableRow);

    let res = await fetch("/users/delete", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            user: user
        })
    });

    if (res.status !== 200) {
        if (!$("#errMsg").length) {
            $(".modal-body").prepend(`<p style="color: red" id="errMsg">an error has occurred please try again</p>`);
        }
    } else {
        $('#exampleModal').modal('hide');
        window.location.reload();
    }

}

function editUser(caller) {

    let tableRow = $(caller).closest('tr');
    let user = getUserFromRow(tableRow);

    $("#edit-user-name").val(user.userName);
    $("#edit-user-password").val(user.password);
    $("#edit-user-mail").val(user.mail);
    $("#edit-user-role").val(user.role);
    $("#edit-user-state").val(user.state);

    $('#editUserModal').modal('show');
}

$(document).ready(function () {
    $('#btn-edit-user').on("click", async function () {

        let modal = $("#editUserModal");
        let userName = modal.find('#edit-user-name').val();
        let password = modal.find('#edit-user-password').val();
        let mail = modal.find('#edit-user-mail').val();
        let role = modal.find('#edit-user-role').val();
        let state = modal.find('#edit-user-state').val();

        let updatedUser = {
            userName : userName,
            password: password,
            mail: mail,
            role: role,
            state: state
        };

        let res = await fetch("/users/update", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                updatedUser: updatedUser
            })
        });

        if (res.status !== 200) {
            if (!$("#errMsg").length) {
                $(".modal-body").prepend(`<p style="color: red" id="errMsg">an error has occurred please try again</p>`);
            }
        } else {
            $('#exampleModal').modal('hide');
            window.location.reload();
        }
    })
});

// empty modal before exit
$(document).ready(function () {
    $('#editUserModal').on('hide.bs.modal', function () {
        removeErrMsg()
    })
});

function getUserFromRow(row){
    let user = {};
    let userFieldsArray = ["userName", "password", "mail", "role","state"];

    row.find('td').each(function (i) {
        let field = $(this).text();
        if(field !== ""){
            user[userFieldsArray[i]] = field;
        }

    });
    return user;
}



