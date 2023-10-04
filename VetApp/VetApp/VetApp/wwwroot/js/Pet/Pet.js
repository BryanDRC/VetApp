$(document).on("click", "#btnAddPet", function () {

    $("#petNameModal").prop("readonly", false);
    $("#petSpeciesModal").prop("readonly", false);
    $("#clientNameModal").prop("readonly", false);

    $("#idPetModal").val('');
    $("#petNameModal").val('');
    $("#petSpeciesModal").val('');
    $("#clientNameModal").val('');
    $("#idClientModal").val('');

    $('#petsModal').modal('show');

});


function SavaChanges() {

    let idPet = $("#idPetModal").val();

    if (idPet.trim().length === 0) {
        CreatePet();
    } else {
        UpdatePet();
    }

}

function CreatePet() {
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let clientName = $("#clientNameModal").val();   

    $.ajax({
        type: "POST",
        url: "../Pet/CreatePet",
        dataType: "json",
        data: {
            "petName": petName,
            "petSpecies": petSpecies,
            "clientName": clientName,         
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

function OpenUpdateModal(idPet){
    $.ajax({
        type: "GET",
        url: "../Pet/GetPets?idPet=" + idPet,
        dataType: "json",
        success: function (res) {

            $("#petNameModal").prop("readonly", true);
            $("#petSpeciesModal").prop("readonly", true);
            $("#clientNameModal").prop("readonly", true);

            $("#idPetModal").val(res.idPet);
            $("#petNameModal").val(res.petName);
            $("#petSpeciesModal").val(res.petSpecies);
            $("#clientNameModal").val(res.clientName);

        }
    });
}

function UpdateUser() {

    let idPet = $("#idPetModal").val();
    let petName = $("#petNameModal").val();
    let petSpecies = $("#petSpeciesModal").val();
    let clientName = $("#clientNameModal").val();

    $.ajax({
        type: "PUT",
        url: "../Pet/UpdatePet",
        dataType: "json",
        data: {
            "idPet": idPet,
            "petName": petName,
            "petSpecies": petSpecies,
            "clientName": clientName,
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

function OpenDeleteConfirmModal(idPet) {
    id = idPet;
    $('#deletePetModal').modal('show');   
}

function DeletePet() {
    $.ajax({
        type: "DELETE",
        url: "../Pet/DeletePet?idPet=" + id,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                $('#deletePetModal').modal('hide');
                alert("Eliminado correctamente");
                location.reload();
                return;
            }
            alert("Ha ocurrido un error");

        }
    });
}


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

