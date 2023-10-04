$(document).on("click", "#btnAddClient", function () {

    $("#clientNameModal").prop("readonly", false);
    $("#clientFirstLastNameModal").prop("readonly", false);
    $("#clientSecondLastNameModal").prop("readonly", false);
    $("#clientIdCardModal").prop("readonly", false);
    $("#clientphoneNumberModal").prop("readonly", false);

    $("#clientNameModal").val('');
    $("#clientFirstLastNameModal").val('');
    $("#clientSecondLastNameModal").val('');
    $("#clientIdCardModal").val('');
    $("#userclientphoneNumberModalMailModal").val('');


    $('#clientsModal').modal('show');

});


function SaveChangesClientModal() {

    let idClient= $("#idClientModal").val();

    let validateInput = validateInputs();

    if (validateInput) {

        if (idClient.trim().length === 0) {
            CreateUser();
        } else {
            UpdateUser();
        }

    }


}

function CreateClient() {
    let clientName = $("#clientNameModal").val();
    let clientFirstLastName = $("#clientFirstLastNameModal").val();
    let clientSecondLastName = $("#clientSecondLastNameModal").val();
    let clientIdCard = $("#clientIdCardModal").val();
    let clientPhoneNumber = $("#clientphoneNumberModal").val();


    $.ajax({
        type: "POST",
        url: "../Client/CreateClient",
        dataType: "json",
        data: {
            "clientName": clientName,
            "clientFirstLastName": clientFirstLastName,
            "clientSecondLastName": clientSecondLastName,
            "clientIdCard": clientIdCard,
            "clientPhoneNumber": clientPhoneNumber
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cliente registrado correctamente.',
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result['isConfirmed']) {
                        location.reload();
                    }
                })

                return;
            }
            Swal.fire({
                icon: 'error',
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });

}

function OpenUpdateClientModal(idClient) {
    $.ajax({
        type: "GET",
        url: "../Client/GetClient?idClient=" + idClient,
        dataType: "json",
        success: function (res) {

            $("#clientNameModal").prop("readonly", false);
            $("#clientFirstLastNameModal").prop("readonly", false);
            $("#clientSecondLastNameModal").prop("readonly", false);
            $("#clientIdCardModal").prop("readonly", false);
            $("#userphoneNumberModal").prop("readonly", false);


            $("#clientNameModal").val(res.clientName);
            $("#clientFirstLastNameModal").val(res.clientFirstLastName);
            $("#clientSecondLastNameModal").val(res.clientSecondLastName);
            $("#clientIdCardModal").val(res.clientIdCard);
            $("#clientphoneNumberModal").val(res.clientphoneNumber);

            $('#clientsModal').modal('show');

        }
    });
}

function UpdateClient() {

    let idClient = $("#idClientModal").val();
    let clientName = $("#clientNameModal").val();
    let clientFirstLastName = $("#clientFirstLastNameModal").val();
    let clientSecondLastName = $("#clientSecondLastNameModal").val();
    let clientphoneNumber = $("#clientphoneNumberModal").val();
    let clientIdCard = $("#clientIdCardModal").val();

    $.ajax({
        type: "PUT",
        url: "../Client/UpdateClient",
        dataType: "json",
        data: {
            "idClient": idClient,
            "clientName": clientName,
            "clientFirstLastName": clientFirstLastName,
            "clientSecondLastName": clientSecondLastName,
            "clientIdCard": clientIdCard,
            "clientphoneNumber": clientphoneNumber
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'cliente actualizado correctamente.',
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result['isConfirmed']) {
                        location.reload();
                    }
                })

                return;
            }

            Swal.fire({
                icon: 'error',
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });

}

let id = 0;

function OpenDeleteConfirmClientModal(idClient) {
    id = idClient;
    $('#deleteClientModal').modal('show');
}

function DeleteClient() {
    $.ajax({
        type: "DELETE",
        url: "../Client/DeleteClient?idClient=" + id,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cliente eliminado correctamente.',
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result['isConfirmed']) {
                        location.reload();
                    }
                })
                return;
            }

            Swal.fire({
                icon: 'error',
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

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

function validateInputsClient() {

    let clientName = $("#clientNameModal").val();
    let clientFirstLastName = $("#clientFirstLastNameModal").val();
    let clientSecondLastName = $("#clientSecondLastNameModal").val();
    let clientIdCard = $("#clientIdCardModal").val();
    let clientPhoneNumber = $("#clientphoneNumberModal").val();


    if (clientName.trim().length === 0) {
        return false;
    }

    if (clientFirstLastName.trim().length === 0) {
        return false;
    }

    if (clientSecondLastName.trim().length === 0) {
        return false;
    }

    if (clientIdCard.trim().length === 0) {
        return false;
    }

    if (clientPhoneNumber.trim().length === 0) {
        return false;
    }

    return true;
}