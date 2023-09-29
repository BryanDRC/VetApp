$(document).on("click", "#btnGuardarModal", function () {
    RegisterUser();
});

function RegisterUser() {

    let userName = $("#userNameModal").val();
    let userFirstLastName = $("#userFirstLastNameModal").val();
    let userSecondLastName = $("#userSecondLastNameModal").val();
    let userMail = $("#userMailModal").val();
    let userNickName = $("#userNickNameModal").val();
    let userPassword = $("#userPasswordModal").val();
    let userPicture = $("#userPictureModal").val();
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
                return;
            }
            alert("Ha ocurrido un error");
            //window.location.href = "/Usuarios/ConsultarUsuarios";

        }
    });

}
