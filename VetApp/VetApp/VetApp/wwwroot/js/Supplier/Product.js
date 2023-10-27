$(document).on("click", "#btnAddProduct", function () {

    $("#idProduct").prop("readonly", false);
    $("#idSupplier").prop("readonly", false);
    $("#product").prop("readonly", false);
    $("#productBuyCost").prop("readonly", false);
    $("#productSellCost").prop("readonly", false);

    $("#idProduct").val('');
    $("#idSupplier").val('');
    $("#product").val('');
    $("#productBuyCost").val('');
    $("#productSellCost").val('');

    $('#productsModal').modal('show');

});



function SavaChangesProductModal() {

    let idProduct = $("#idProductModal").val();

    let validateInput = validateInputs();


    if (validateInput) {

        if (idProduct.trim().length === 0) {
            CreateProduct();
        } else {
            UpdateProduct();
        }

    }


}

function CreateProduct() {
    let idSupplier = $("#idSupplierModal").val();
    let product = $("#productModal").val();
    let productBuyCost = $("#productBuyCostModal").val();
    let productSellCost = $("#productSellCostModal").val();

    $.ajax({
        type: "POST",
        url: "../Product/CreateProduct",
        dataType: "json",
        data: {
            "idSupplier": idSupplier,
            "product": product,
            "productBuyCost": productBuyCost,
            "productSellCost": productSellCost,
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Producto registrado correctamente.',
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

function OpenUpdateProductModal(idProduct) {
    $.ajax({
        type: "GET",
        url: "../Product/GetProduct?idProduct=" + idProduct,
        dataType: "json",
        success: function (res) {

            $("#idSupplierModal").prop("readonly", true);
            $("#productModal").prop("readonly", false);
            $("#productBuyCostModal").prop("readonly", false);
            $("#productSellCostModal").prop("readonly", false);


            $("#idProductModal").val(res.idProduct);
            $("#idSupplierModal").val(res.productName);
            $("#productModal").val(res.productPhoneNumber);
            $("#productBuyCostModal").val(res.productIdCard);
            $("#productSellCostModal").val(res.productIdCard);

            $('#productsModal').modal('show');

        }
    });
}

function UpdateProduct() {

    let idProduct = $("#idProductModal").val();
    let idSupplier = $("#idSupplierModal").val();
    let product = $("#productModal").val();
    let productBuyCost = $("#productBuyCostModal").val();
    let productSellCost = $("#productSellCostModal").val();

    $.ajax({
        type: "PUT",
        url: "../Product/UpdateProduct",
        dataType: "json",
        data: {
            "idProduct": idProduct,
            "idSupplier": idSupplier,
            "product": product,
            "productBuyCost": productBuyCost,
            "productSellCost": productSellCost
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Producto actualizado correctamente.',
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

function OpenDeleteConfirmProductModal(idProduct) {
    id = idProduct;
    $('#deleteProductModal').modal('show');
}

function DeleteProduct() {
    $.ajax({
        type: "DELETE",
        url: "../Product/DeleteProduct?idProduct=" + id,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Producto eliminado correctamente.',
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

    let idSupplier = $("#idSupplierModal").val();
    let product = $("#productModal").val();
    let productBuyCost = $("#productBuyCostModal").val()
    let productSellCost = $("#productSellCostModal").val()

    let idSupplierMessage = $("#idSupplierMessage");
    let productMessage = $("#productMessage");
    let productBuyCostrMessage = $("#productBuyCostMessage");
    let productSellCostMessage = $("#productSellCostMessage");


    idSupplierMessage.text("");
    productMessage.text("");
    productBuyCostrMessage.text("");
    productSellCostMessage.text("");

    if (idSupplier.trim().length === 0) {
        idSupplierMessage.text("Id no puede ir vac\u00EDo.");
        return false;
    }

    if (product.trim().length === 0) {
        productMessage.text("Producto fiscal no puede ir vac\u00EDo.");
        return false;
    }

    if (productBuyCost.trim().length === 0) {
        productBuyCostrMessage.text("Precio de compra no puede ir vac\u00EDo.");
        return false;
    }

    if (productSellCost.trim().length < 8) {
        productSellCostMessage.text("Precio de venta no puede ir vac\u00EDo.");
        return false;
    }

    return true;
}