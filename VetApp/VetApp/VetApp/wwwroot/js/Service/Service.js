$(document).on("click", "#btnAddService", function () {
    $("#serviceNameModal").val('');
    $("#serviceCostModal").val('');
    $("#idServiceModal").val('');

    $('#servicesModal').modal('show');
});

function SaveChangesServiceModal() {
    let idService = $("#idServiceModal").val();
    let validateInput = validateServiceInputs();

    if (validateInput) {
        if (idService.trim().length === 0) {
            CreateService();
        } else {
            UpdateService();
        }
    }
}

function CreateService() {
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = parseFloat($("#serviceCostModal").val());

    $.ajax({
        type: "POST",
        url: "../Service/CreateService",
        dataType: "json",
        data: {
            "serviceName": serviceName,
            "serviceCost": serviceCost
        },
        success: function (res) {
            // Manejar la respuesta del servidor
            // Similar a la función CreatePet
        }
    });
}

function OpenUpdateServiceModal(idService) {
    $.ajax({
        type: "GET",
        url: "../Service/GetService?idService=" + idService,
        dataType: "json",
        success: function (res) {
            // Rellenar los campos del modal con la información del servicio
            // Similar a la función OpenUpdatePetModal
        }
    });
}

function UpdateService() {
    let idService = $("#idServiceModal").val();
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = parseFloat($("#serviceCostModal").val());

    $.ajax({
        type: "PUT",
        url: "../Service/UpdateService",
        dataType: "json",
        data: {
            "IdService": idService,
            "serviceName": serviceName,
            "serviceCost": serviceCost
        },
        success: function (res) {
            // Manejar la respuesta del servidor
            // Similar a la función UpdatePet
        }
    });
}

let idTempService = 0;

function OpenDeleteConfirmServiceModal(idService) {
    idTempService = idService;
    $('#deleteServiceModal').modal('show');
}

function DeleteService() {
    $.ajax({
        type: "DELETE",
        url: "../Service/DeleteService?idService=" + idTempService,
        dataType: "json",
        success: function (res) {
            // Manejar la respuesta del servidor
            // Similar a la función DeletePet
        }
    });
}

function validateServiceInputs() {
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = $("#serviceCostModal").val();

    let serviceNameMessage = $("#serviceNameModalMessage");
    let serviceCostMessage = $("#serviceCostModalMessage");

    serviceNameMessage.text("");
    serviceCostMessage.text("");

    if (serviceName.trim().length === 0) {
        serviceNameMessage.text("El nombre del servicio no puede estar vacío.");
        return false;
    }
    if (serviceCost.trim().length === 0 || isNaN(serviceCost)) {
        serviceCostMessage.text("El costo del servicio debe ser un número válido.");
        return false;
    }

    return true;
}
