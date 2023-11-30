$(document).on("click", "#btnAddForms", function () {

    $("#useIdModal").prop("readonly", false);
    $("#petNameModal").prop("readonly", false);
    $("#speciesNameModal").prop("readonly", false);
    $("#cardClientModal").prop("readonly", false);
    $("#motiveFormsModal").prop("readonly", false);
    $("#arrivalFormsModal").prop("readonly", false);
    $("#attentionFormsModal").prop("readonly", false);
    $("#productIdModal").prop("readonly", false);
    $("#servicIdModal").prop("readonly", false);

    $("#idFormsModal").val('');
    $("#useIdModal").val('');
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

    let idClient = $("#idFormsModal").val();

    //let validateInput = validateInputs();


   // if (validateInput) {

        if (idClient.trim().length === 0) {
            CreateForms();
        } else {
            //UpdateClient();
        }

    //}


}

function CreateForms() {
    let idUser = $("#useIdModal").val();
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
            "IdUser": idUser,
            "Pet_Name": petName,
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