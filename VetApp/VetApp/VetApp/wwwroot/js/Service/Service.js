$(document).on("click", "#btnAddService", function () {

    $("#idServiceModal").prop("readonly", false);
    $("#serviceNameModal").prop("readonly", false);
    $("#serviceCostModal").prop("readonly", false);


    $("#idServiceModal").val('');
    $("#serviceNameModal").val('');
    $("#serviceCostModal").val('');


    $('#servicesModal').modal('show');

});



function SavaChangesServiceModal() {

    let idService = $("#idServiceModal").val();

    let validateInput = validateInputs();


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
    let serviceCost = $("#serviceCostModal").val();

    $.ajax({
        type: "POST",
        url: "../Service/CreateService",
        dataType: "json",
        data: {
            "serviceName": serviceName,
            "serviceCost": serviceCost
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Servicio registrado correctamente.',
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

function OpenUpdateServiceModal(idService) {
    $.ajax({
        type: "GET",
        url: "../Service/GetService?idService=" + idService,
        dataType: "json",
        success: function (res) {

            $("#serviceNameModal").prop("readonly", false);
            $("#serviceCostModal").prop("readonly", false);



            $("#idServiceModal").val(res.idService);
            $("#serviceNameModal").val(res.serviceName);
            $("#serviceCostModal").val(res.serviceCost);


            $('#servicesModal').modal('show');

        }
    });
}

function UpdateService() {

    let idService = $("#idServiceModal").val();
    let serviceName = $("#serviceNameModal").val();
    let serviceCost = $("#serviceCostModal").val();

    $.ajax({
        type: "PUT",
        url: "../Service/UpdateService",
        dataType: "json",
        data: {
            "idService": idService,
            "serviceName": serviceName,
            "serviceCost": serviceCost
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Servicio actualizado correctamente.',
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

let idtempService= 0;

function OpenDeleteConfirmServiceModal(idService) {
    id = idService;
    $('#deleteServiceModal').modal('show');
}

function DeleteService() {
    $.ajax({
        type: "DELETE",
        url: "../Service/DeleteService?idService=" + idtempService,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Servicio eliminado correctamente.',
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

function validateInputs() {

    let serviceName = $("#serviceNameModal").val();
    let serviceCost = $("#serviceCostModal").val()

    let serviceNameMessage = $("#serviceNameModalMessage");
    let serviceCostMessage = $("#serviceCostModalMessage");


    serviceNameMessage.text("");
    serviceCostMessage.text("");

    if (serviceName.trim().length === 0) {
        serviceNameMessage.text("Nombre del servicio no puede ir vac\u00EDo.");
        return false;
    }

    if (serviceCost.trim().length === 0) {
        serviceCostMessage.text("El precio no puede ir vac\u00EDo.");
        return false;
    }


    return true;
}