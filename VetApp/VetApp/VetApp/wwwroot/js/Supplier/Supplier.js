$(document).on("click", "#btnAddSupplier", function () {

    $("#supplierNameModal").prop("readonly", false);
    $("#supplierPhoneNumberModal").prop("readonly", false);
    $("#supplierIdCardModal").prop("readonly", false);



    $("#idSupplierModal").val('');
    $("#supplierNameModal").val('');
    $("#supplierPhoneNumberModal").val('');
    $("#supplierIdCardModal").val('');



    $('#suppliersModal').modal('show');

});

function SavaChangesSupplierModal() {

    let idSupplier = $("#idSupplierModal").val();

    let validateInput = validateInputs();


    if (validateInput) {

        if (idSupplier.trim().length === 0) {
            CreateSupplier();
        } else {
            UpdateSupplier();
        }

    }


}

function CreateSupplier() {
    let supplierName = $("#supplierNameModal").val();
    let supplierPhoneNumber = $("#supplierPhoneNumberModal").val();
    let supplierIdCard = $("#supplierIdCardModal").val();



    $.ajax({
        type: "POST",
        url: "../Supplier/CreateSupplier",
        dataType: "json",
        data: {
            "supplierName": supplierName,
            "supplierPhoneNumber": supplierPhoneNumber,
            "supplierIdCard": supplierIdCard

        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Proveedor registrado correctamente.',
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

function OpenUpdateSupplierModal(idSupplier) {
    $.ajax({
        type: "GET",
        url: "../Supplier/GetSupplier?idSupplier=" + idSupplier,
        dataType: "json",
        success: function (res) {

            $("#supplierNameModal").prop("readonly", false);
            $("#supplierIdCardModal").prop("readonly", false);
            $("#supplierPhoneNumberModal").prop("readonly", false);



            $("#idSupplierModal").val(res.idSupplier);
            $("#supplierNameModal").val(res.supplierName);
            $("#supplierPhoneNumberModal").val(res.supplierPhoneNumber);
            $("#supplierIdCardModal").val(res.supplierIdCard);



            $('#suppliersModal').modal('show');

        }
    });
}

function UpdateSupplier() {

    let idSupplier = $("#idSupplierModal").val();
    let supplierName = $("#supplierNameModal").val();
    let supplierPhoneNumber = $("#supplierPhoneNumberModal").val();
    let supplierIdCard = $("#supplierPasswordModal").val();



    $.ajax({
        type: "PUT",
        url: "../Supplier/UpdateSupplier",
        dataType: "json",
        data: {
            "idSupplier": idSupplier,
            "supplierName": supplierName,
            "supplierPhoneNumber": supplierPhoneNumber,
            "supplierIdCard": supplierIdCard
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Proveedor actualizado correctamente.',
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

let idtemp = 0;

function OpenDeleteConfirmSupplierModal(idSupplier) {
    idtemp = idSupplier;
    $('#deleteSupplierModal').modal('show');
}

function DeleteSupplier() {
    $.ajax({
        type: "DELETE",
        url: "../Supplier/DeleteSupplier?idSupplier=" + idtemp,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Proveedor eliminado correctamente.',
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

    let supplierName = $("#supplierNameModal").val();
    let supplierPhoneNumber = $("#supplierPhoneNumberModal").val();
    let supplierIdCard = $("#supplierIdCardModal").val();


    let supplierNameMessage = $("#supplierNameModalMessage");
    let supplierPhoneNumberMessage = $("#supplierPhoneNumberModalMessage");
    let supplierIdCardMessage = $("#supplierIdCardModalMessage");



    supplierNameMessage.text("");
    supplierPhoneNumberMessage.text("");
    supplierIdCardMessage.text("");


    if (supplierName.trim().length === 0) {
        supplierNameMessage.text("Nombre no puede ir vac\u00EDo.");
        return false;
    }

    if (supplierPhoneNumber.trim().length === 0) {
        supplierPhoneNumberMessage.text("Tel\u00E9fono no puede ir vac\u00EDo.");
        return false;
    }

    if (supplierPhoneNumber.trim().length < 8) {
        supplierPhoneNumberMessage.text("Debe tener m\u00EDnimo 8 n\u00FAmeros.");
        return false;
    }

    if (supplierIdCard.trim().length === 0) {
        supplierIdCardMessage.text("C\u00E9dula no puede ir vac\u00EDo.");
        return false;
    }



    return true;
}