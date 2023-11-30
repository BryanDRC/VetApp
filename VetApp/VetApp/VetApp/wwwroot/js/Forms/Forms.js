$(document).on("click", "#btnAddForms", function () {

    $("#userIdModal").prop("readonly", false);
    $("#petNameModal").prop("readonly", false);
    $("#speciesNameModal").prop("readonly", false);
    $("#cardClientModal").prop("readonly", false);
    $("#motiveFormsModal").prop("readonly", false);
    $("#arrivalFormsModal").prop("readonly", false);
    $("#attentionFormsModal").prop("readonly", false);
    $("#productIdModal").prop("readonly", false);
    $("#servicIdModal").prop("readonly", false);

    $("#idMedicalRecordModal").val('');
    $("#userIdModal").val('');
    $("#petNameModal").val('');
    $("#speciesNameModal").val('');
    $("#cardClientModal").val('');
    $("#motiveFormsModal").val('');
    $("#arrivalFormsModal").val('');
    $("#attentionFormsModal").val('');
    $("#productIdModal").val('');
    $("#servicIdModal").val('');


    $('#formsModal').modal('show');

});

function SavaChangesClientModal() {

    let idMedicalRecord = $("#idMedicalRecordModal").val();

    //let validateInput = validateInputs();


    // if (validateInput) {

    if (idMedicalRecord.trim().length === 0) {
        CreateForms();
    } else {
        UpdateForms();
    }

    //}


}

function CreateForms() {
    let idUser = $("#userIdModal").val();
    let petName = $("#petNameModal").val();
    let petSpecies = $("#speciesNameModal").val();
    let clientIdName = $("#cardClientModal").val();
    let motive = $("#motiveFormsModal").val();
    let arrival = $("#arrivalFormsModal").val();
    let attention = $("#attentionFormsModal").val();
    let idProduct = $("#productIdModal").val();
    let idService = $("#servicIdModal").val();


    $.ajax({
        type: "POST",
        url: "../Forms/CreateForms",
        dataType: "json",
        data: {
            "idUser": idUser,
            "petName": petName,
            "petSpecies": petSpecies,
            "clientIdCard": clientIdName,
            "motive": motive,
            "arrival": arrival,
            "attention": attention,
            "idProduct": idProduct,
            "idService": idService,
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Registrado correctamente.',
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

function OpenUpdateFormsModal(idMedicalRecord) {
    $.ajax({
        type: "GET",
        url: "../Forms/GetForms?idMedicalRecord=" + idMedicalRecord,
        dataType: "json",
        success: function (res) {

            $("#userIdModal").prop("readonly", false);
            $("#petNameModal").prop("readonly", false);
            $("#speciesNameModal").prop("readonly", false);
            $("#cardClientModal").prop("readonly", false);
            $("#arrivalFormsModal").prop("readonly", false);
            $("#attentionFormsModal").prop("readonly", false);
            $("#productIdModal").prop("readonly", false);
            $("#servicIdModal").prop("readonly", false);

            $("#idMedicalRecordModal").val(res.idMedicalRecord);
            $("#userIdModal").val(res.idUser);
            $("#petNameModal").val(res.petName);
            $("#speciesNameModal").val(res.petSpecies);
            $("#cardClientModal").val(res.clientIdCard);
            $("#motiveFormsModal").val(res.motive);
            $("#arrivalFormsModal").val(res.arrival);
            $("#attentionFormsModal").val(res.attention);
            $("#productIdModal").val(res.idProduct);
            $("#servicIdModal").val(res.idService);


            $('#formsModal').modal('show');

        }
    });
}

function UpdateForms() {

    let idMedicalRecord = $("#idMedicalRecordModal").val();
    let idUser = $("#userIdModal").val();
    let petName = $("#petNameModal").val();
    let petSpecies = $("#speciesNameModal").val();
    let clientIdCard = $("#cardClientModal").val();
    let motive = $("#motiveFormsModal").val();
    let arrival = $("#arrivalFormsModal").val();
    let attention = $("#attentionFormsModal").val();
    let idProduct = $("#productIdModal").val();
    let idService = $("#servicIdModal").val();



    $.ajax({
        type: "PUT",
        url: "../Forms/UpdateForms",
        dataType: "json",
        data: {
            "idMedicalRecord": idMedicalRecord,
            "idUser": idUser,
            "petName": petName,
            "petSpecies": petSpecies,
            "clientIdCard": clientIdCard,
            "motive": motive,
            "arrival": arrival,
            "attention": attention,
            "idProduct": idProduct,
            "idService": idService,
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Se actualizo correctamente.',
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



function OpenDeleteConfirmFormsModal(idMedicalRecord) {
    $("#deleteFormsModalId").val(idMedicalRecord);
    $('#deleteFormsModal').modal('show');
}

function DeleteForms() {
    let idtempforms = $("#deleteFormsModalId").val();
    $.ajax({
        type: "DELETE",
        url: "..Forms/DeleteForms?idForms=" + idtempforms,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Se a eliminado correctamente.',
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
