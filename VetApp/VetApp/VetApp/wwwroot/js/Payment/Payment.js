document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('botonAgregar').addEventListener('click', function () {
        var insumosInput = document.getElementById('insumosInput');
        var cantidadInput = document.getElementById('cantidadInput');
        var cantidad = parseFloat(cantidadInput.value);
        var cantidadDescuentoInput = document.getElementById('productoDInput');
        var cantidadDescuento = parseFloat(cantidadDescuentoInput.value) || 0;
        var descuentoInputVal = parseFloat(document.getElementById('descuentoInput').value) / 100 || 0;

        if (insumosInput.value === "") {
            $('#alertaModal').modal('show');
            return;
        }

        if (isNaN(cantidad) || cantidad < 1) {
            $('#cantidadAlertaModal').modal('show');
            return;
        }

        var servicio = insumosInput.options[insumosInput.selectedIndex].text;
        var instrucciones = document.getElementById('instruccionesInput').value;
        var precioUnitario = parseFloat(insumosInput.options[insumosInput.selectedIndex].getAttribute('data-precio')) || 0;
        var precioConDescuento = descuentoInputVal > 0 ? (precioUnitario - (precioUnitario * descuentoInputVal)) : precioUnitario;
        var precioTotalDescuento = precioConDescuento * Math.min(cantidad, cantidadDescuento);
        var precioTotalSinDescuento = precioUnitario * (cantidad - cantidadDescuento);
        var precioTotal = precioTotalDescuento + precioTotalSinDescuento;

        var tabla = document.getElementById('miTabla').getElementsByTagName('tbody')[0];
        var nuevaFila = tabla.insertRow();
        nuevaFila.insertCell(0).innerHTML = servicio;
        nuevaFila.insertCell(1).innerHTML = instrucciones;
        nuevaFila.insertCell(2).innerHTML = cantidad;
        nuevaFila.insertCell(3).innerHTML = precioTotal.toFixed(2);

        // Crear botón de eliminar y añadir a la nueva fila
        var btnEliminar = document.createElement('button');
        btnEliminar.textContent = 'Eliminar';
        btnEliminar.style.color = 'white';
        btnEliminar.style.backgroundColor = 'red';
        btnEliminar.style.border = '1px solid red';
        btnEliminar.onclick = function () {
            this.closest('tr').remove();
            actualizarTotal();
        };
        var celdaEliminar = nuevaFila.insertCell();
        celdaEliminar.appendChild(btnEliminar);


        actualizarTotal();

        // Limpiar los campos de entrada
        document.getElementById('cantidadInput').value = '';
        document.getElementById('instruccionesInput').value = '';
        document.getElementById('descuentoInput').value = '';
        document.getElementById('productoDInput').value = '';
        $('#insumosInput').val(null).trigger('change');
    });

    document.getElementById('ivaPInput').addEventListener('input', actualizarTotal);
    document.getElementById('ivaSInput').addEventListener('input', actualizarTotal);

    function actualizarTotal() {
        var total = 0;
        var tabla = document.getElementById('miTabla').getElementsByTagName('tbody')[0];
        var filas = tabla.getElementsByTagName('tr');

        for (var i = 0; i < filas.length; i++) {
            var precio = parseFloat(filas[i].cells[3].innerHTML) || 0;
            total += precio;
        }

        var ivaPInput = parseFloat(document.getElementById('ivaPInput').value) || 0;
        var totalIVAProducto = total * (ivaPInput / 100);
        var ivaSInput = parseFloat(document.getElementById('ivaSInput').value) || 0;
        var totalIVAServicio = total * (ivaSInput / 100);
        var totalFInput = total + totalIVAProducto + totalIVAServicio;

        document.getElementById('totalpagar').value = total.toFixed(2);
        document.getElementById('totalFInput').value = totalFInput.toFixed(2);
        document.getElementById('preciofinalInput').value = totalFInput.toFixed(2);
    }

    

});

function getDetailsTable() {
    var datos = [];
    $('#miTabla tbody tr').each(function () {
        var fila = {
            nameDetail: $(this).find('td').eq(0).text(),
            descriptionDetail: $(this).find('td').eq(1).text(),
            amountDetail: parseInt($(this).find('td').eq(2).text()),
            costDetail: parseInt($(this).find('td').eq(3).text())
        };
        datos.push(fila);
    });
    return datos;
}

function CreateInvoices() {

    var detailInvoice = getDetailsTable();

    //var numReference = $('#numReference').val();
    var dateInvoices = $('#fechaInput').val();
    var totalCancel = parseInt($('#preciofinalInput').val());
    var totalCanceled = parseInt($('#canceladoInput').val());
    var idPaymentType = $('#tipopagoInput').val();
    var idClient = $('#clienteInput').val();

    $.ajax({
        type: "POST",
        url: "../Payment/CreateInvoices",
        dataType: "json",
        data: {
            "numReference": 0,
            "dateInvoices": dateInvoices,
            "totalCancel": totalCancel,
            "totalCanceled": totalCanceled,
            "idPaymentType": idPaymentType,
            "idClient": idClient,
            "detailInvoices": detailInvoice
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Factura registrada correctamente.',
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

function validateAmount() {

    let totalCancel = parseFloat($('#preciofinalInput').val());
    let totalCanceled = parseFloat($('#canceladoInput').val());

    let result = totalCanceled - totalCancel;

    if (result > 0) {
        parseFloat($('#vueltoInput').val(result));
    } else {
        parseFloat($('#vueltoInput').val(0));
    } 

}