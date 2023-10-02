$(document).on("click", "#btnAddEmployee", function () {

    $("#userNameModal").prop("readonly", false);
    $("#userFirstLastNameModal").prop("readonly", false);
    $("#userSecondLastNameModal").prop("readonly", false);
    $("#userIdCardModal").prop("readonly", false);

    $("#idUserModal").val('');
    $("#userNameModal").val('');
    $("#userFirstLastNameModal").val('');
    $("#userSecondLastNameModal").val('');
    $("#userMailModal").val('');
    $("#userNickNameModal").val('');
    $("#userPhoneNumberModal").val('');
    $("#userIdCardModal").val('');

    $('#usersModal').modal('show');

});

let userPicture = $("#userPictureModal").val();

function SavaChanges() {

    let idUser = $("#idUserModal").val();

    if (idUser.trim().length === 0) {
        CreateUser();
    } else {
        UpdateUser();
    }

}

function CreateUser() {
    let userName = $("#userNameModal").val();
    let userFirstLastName = $("#userFirstLastNameModal").val();
    let userSecondLastName = $("#userSecondLastNameModal").val();
    let userMail = $("#userMailModal").val();
    let userNickName = $("#userNickNameModal").val();
    let userPassword = $("#userPasswordModal").val();
    let userPhoneNumber = $("#userPhoneNumberModal").val();
    let idRol = $("#idRolModal").val();
    let userIdCard = $("#userIdCardModal").val();

    $.ajax({
        type: "POST",
        url: "../Administration/CreateUser",
        dataType: "json",
        data: {
            "userName": userName,
            "userFirstLastName": userFirstLastName,
            "userSecondLastName": userSecondLastName,
            "userMail": userMail,
            "userNickName": userNickName,
            "userPassword": userPassword,
            "userPicture": userPicture,
            "userPhoneNumber": userPhoneNumber,
            "idRol": idRol,
            "userIdCard": userIdCard
        },
        success: function (res) {

            if (res == 1) {
                alert("Registro correctamente");
                location.reload();
                return;
            }
            alert("Ha ocurrido un error");

        }
    });

}

function OpenUpdateModal(idUser){
    $.ajax({
        type: "GET",
        url: "../Administration/GetUser?idUser=" + idUser,
        dataType: "json",
        success: function (res) {

            $("#userNameModal").prop("readonly", true);
            $("#userFirstLastNameModal").prop("readonly", true);
            $("#userSecondLastNameModal").prop("readonly", true);
            $("#userIdCardModal").prop("readonly", true);
            $("#userPasswordModal").val('')

            $("#idUserModal").val(res.idUser);
            $("#userNameModal").val(res.userName);
            $("#userFirstLastNameModal").val(res.userFirstLastName);
            $("#userSecondLastNameModal").val(res.userSecondLastName);
            $("#userMailModal").val(res.userMail);
            $("#userNickNameModal").val(res.userNickName);
            $("#userPhoneNumberModal").val(res.userPhoneNumber);
            $("#idRolModal").val(res.idRol);
            $("#userIdCardModal").val(res.userIdCard);

            $('#usersModal').modal('show');

        }
    });
}

function UpdateUser() {

    let idUser = $("#idUserModal").val();
    let userMail = $("#userMailModal").val();
    let userNickName = $("#userNickNameModal").val();
    let userPassword = $("#userPasswordModal").val();
    let userPhoneNumber = $("#userPhoneNumberModal").val();
    let idRol = $("#idRolModal").val();
    let userIdCard = $("#userIdCardModal").val();

    $.ajax({
        type: "PUT",
        url: "../Administration/UpdateUser",
        dataType: "json",
        data: {
            "idUser": idUser,
            "idRol": idRol,
            "userMail": userMail,
            "userNickName": userNickName,
            "userPassword": userPassword,
            "userPicture": userPicture,
            "userPhoneNumber": userPhoneNumber,
            "userIdCard": userIdCard
        },
        success: function (res) {

            if (res == 1) {
                alert("Actualizado correctamente");
                location.reload();
                return;
            }
            alert("Ha ocurrido un error");

        }
    });

}

let id = 0;

function OpenDeleteConfirmModal(idUser) {
    id = idUser;
    $('#deleteUserModal').modal('show');   
}

function DeleteUser() {
    $.ajax({
        type: "DELETE",
        url: "../Administration/DeleteUser?idUser=" + id,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                $('#deleteUserModal').modal('hide');
                alert("Eliminado correctamente");
                location.reload();
                return;
            }
            alert("Ha ocurrido un error");

        }
    });
}

// Selecciona el elemento de entrada de archivo (input type="file") en tu HTML
const input = document.getElementById('userPictureModal');

// Agrega un evento para escuchar cuando se selecciona un archivo
input.addEventListener('change', function () {
    const file = input.files[0];

    // Crea un objeto FileReader
    const reader = new FileReader();

    // Define la función de devolución de llamada que se ejecutará cuando se cargue el archivo
    reader.onload = function () {
        // El contenido de la imagen en Base64 estará en reader.result
        const base64Image = reader.result;
        userPicture = base64Image;
    };

    // Lee el archivo como una URL de datos (Base64)
    reader.readAsDataURL(file);
});

