$(document).on("click", "#btnAddPet", function () {


    $("#petNameModal").prop("readonly", false);
    $("#petSpeciesModal").prop("readonly", false);
    $("#idClientModal").prop("readonly", false);

    $("#idPetModal").val('');
    $("#petNameModal").val('');
    $("#petSpeciesModal").val('');
    $("#idClientModal").val('');

    $('#petsModal').modal('show');

});

function SavaChangesPetModal() {
    let idPet = $("#idPetModal").val();
    let validateInput = validateInputs();

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

    $.ajax({
        type: "POST",
        url: "../Pet/CreatePet",
        dataType: "json",
        data: {
            "petName": petName,
            "petSpecies": petSpecies,
            "idClient" : idClient
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
            $("#idClientModal").prop("readonly", false);

            $("#idPetModal").val(res.IdPet);
            $("#petNameModal").val(res.petName);
            $("#petSpeciesModal").val(res.petSpecies);
            $("#idClientModal").val(res.idClient);

            $('#petsModal').modal('show');
        }
    });
}

function UpdatePet() {
    let idPet = $("#idPetModal").val();
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let idClient = $("#idClientModal").val();

    $.ajax({
        type: "PUT",
        url: "../Pet/UpdatePet",
        dataType: "json",
        data: {
            "IdPet": idPet,
            "petName": petName,
            "petSpecies": petSpecies,
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

function validateInputs() {
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let idClient = $("#idClientModal").val();

    let petNameMessage = $("#petNameModalMessage");
    let petSpeciesMessage = $("#petSpeciesModalMessage");
    let idClientMessage = $("#idClientModalMessage");

    petNameMessage.text("");
    petSpeciesMessage.text("");
    idClientMessage.text("");

    if (petName.trim().length === 0) {
        petNameMessage.text("Nombre de la mascota no puede ir vacío.");
        return false;
    }
    if (petSpecies.trim().length === 0) {
        petSpeciesMessage.text("Especie de la mascota no puede ir vacío.");
        return false;
    }

    if (idClient.trim().length === 0) {
        idClientMessage.text("Id del cliente no puede ir vacío.");
        return false;
    }


    return true;
}
