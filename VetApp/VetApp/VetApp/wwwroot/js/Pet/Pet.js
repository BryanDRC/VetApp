$(document).on("click", "#btnAddPet", function () {

    $("#petNameModal").prop("readonly", false);
    $("#petSpeciesModal").prop("readonly", false);
    $("#birthDateModal").prop("readonly", false);


    $("#petNameModal").val('');
    $("#petSpeciesModal").val('');
    $("#birthDateModal").val('');


    $('#petsModal').modal('show');

});

function SavaChangesPetModal() {
    let idPet = $("#idPetModal").val();
    let validateInput = validatePetInputs();

    if (validateInput) {
        if (idPet.trim().length === 0) {
            CreatePet();
        } else {
            UpdatePet();
        }
    }
}

function CreatePet() {
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let idClient = $("#idClientModal").val();
    let birthDate = $("#birthDateModal").val();

    $.ajax({
        type: "POST",
        url: "../Pet/CreatePet",
        dataType: "json",
        data: {
            "petName": petName,
            "petSpecies": petSpecies,
            "idClient": idClient,
            "birthDate": birthDate
        },
        success: function (res) {
            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Mascota registrada correctamente.',
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
                title: 'Error',
                text: 'Lo sentimos ha ocurrido un error.',
            });
        }
    });
}

function OpenUpdatePetModal(idPet) {
    $.ajax({
        type: "GET",
        url: "../Pet/GetPet?idPet=" + idPet,
        dataType: "json",
        success: function (res) {
            $("#petNameModal").prop("readonly", false);
            $("#petSpeciesModal").prop("readonly", false);
            $("#birthDateModal").prop("readonly", false);

            $("#idPetModal").val(res.idPet);
            $("#petNameModal").val(res.petName);
            $("#petSpeciesModal").val(res.petSpecies);
            $("#birthDateModal").val(res.birthDate);
            $("#idClientModal").val(res.idClient);
            $("#birthDateModal").val(res.birthDate);

            $('#petsModal').modal('show');
        }
    });
}

function UpdatePet() {
    let idPet = $("#idPetModal").val();
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let idClient = $("#idClientModal").val();
    let birthDate = $("#birthDateModal").val();

    $.ajax({
        type: "PUT",
        url: "../Pet/UpdatePet",
        dataType: "json",
        data: {
            "IdPet": idPet,
            "petName": petName,
            "petSpecies": petSpecies,
            "birthDate": birthDate,
            "idClient": idClient
        },
        success: function (res) {
            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Mascota actualizada correctamente.',
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
                title: 'Error',
                text: 'Lo sentimos ha ocurrido un error.',
            });
        }
    });
}

let idtempPet = 0;

function OpenDeleteConfirmPetModal(idPet) {
    idtempPet = idPet;
    $('#deletePetModal').modal('show');
}

function DeletePet() {
    $.ajax({
        type: "DELETE",
        url: "../Pet/DeletePet?idPet=" + idtempPet,
        dataType: "json",
        success: function (res) {
            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Mascota eliminada correctamente.',
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
                title: 'Error',
                text: 'Lo sentimos ha ocurrido un error.',
            });
        }
    });
}


function validatePetInputs() {
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let birthDate = $("#birthDateModal").val();


    let petNameMessage = $("#petNameModalMessage");
    let petSpeciesMessage = $("#petSpeciesModalMessage");
    let birthDateMessage = $("#birthDateModalMessage");

    petNameMessage.text("");
    petSpeciesMessage.text("");
    birthDateMessage.text("");

    if (petName.trim().length === 0) {
        petNameMessage.text("Nombre de la mascota no puede ir vacío.");
        return false;
    }
    if (petSpecies.trim().length === 0) {
        petSpeciesMessage.text("Especie de la mascota no puede ir vacío.");
        return false;
    }
    if (birthDate.trim().length === 0) {
        birthDateMessage.text("Fecha de Nacimiento no puede ir vacio.");
        return false;
    }

    if (birthDate.trim().length === 0) {
        birthDateMessage.text("Fecha de nacimiento de la mascota no puede ir vacío.");
        return false;
    }


    return true;
}
