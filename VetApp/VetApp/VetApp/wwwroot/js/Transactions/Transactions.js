function ShowDetailsInvoicesModal(idInvoice) {
    $.ajax({
        type: "GET",
        url: "../Reportes/GetDetailByIdInvoices?idInvoice=" + idInvoice,
        dataType: "json",
        success: function (res) {

            CreateDetailsInvoicesTbl(res);

            $('#detailsInvoicesModal').modal('show');

        }
    });
}

function CreateDetailsInvoicesTbl(list) {

    let dtDetails = document.getElementById("dtDetailsInvoice"); 

    $("#dtDetailsInvoice").find("tr:gt(0)").remove();
    for (var i = 0; i < list.length; i++) {
        var row = dtDetails.insertRow();
        var cell1 = row.insertCell();
        var cell2 = row.insertCell();
        var cell3 = row.insertCell();
        var cell4 = row.insertCell();
        var cell5 = row.insertCell();
        cell1.innerHTML = list[i]["idDetail"];
        cell2.innerHTML = list[i]["nameDetail"];
        cell3.innerHTML = list[i]["descriptionDetail"];
        cell4.innerHTML = list[i]["amountDetail"];
        cell5.innerHTML = list[i]["costDetail"];
        //let recibo = list[i]["Recibo"];
        //cell1.innerHTML = recibo;
        //cell2.innerHTML = list[i]["Fecha"];
        //let button = "'" + list[i]["Receipt_GUID"] + "'";
        //cell3.innerHTML = '<a id="' + i + '" onclick="OpenDetailsModal(' + button.toString() + ',' + "'" + list[i]["Recibo"] + "'" + ')" class="btn btn-primary" data-toggle="tooltip" data-original-title="Edit user" style="cursor:pointer; background-color: #20295b; border-color: #20295b;">Ver más</a>';
    }
}


function ShowInvoicesCreditsModal(idClient) {
    $.ajax({
        type: "GET",
        url: "../Reportes/GetDepositsCreditsByIdClient?idClient=" + idClient,
        dataType: "json",
        success: function (res) {

            CreateInvoicesCreditsTbl(res);

            $('#invoicesCreditsModal').modal('show');

        }
    });
}

function CreateInvoicesCreditsTbl(list) {

    let dtDetails = document.getElementById("dtInvoicesCredits");

    $("#dtInvoicesCredits").find("tr:gt(0)").remove();
    for (var i = 0; i < list.length; i++) {
        var row = dtDetails.insertRow();
        var cell1 = row.insertCell();
        var cell2 = row.insertCell();
        var cell3 = row.insertCell();
        var cell4 = row.insertCell();
        var cell5 = row.insertCell();
        var cell6 = row.insertCell();
        var cell7 = row.insertCell();
        var cell8 = row.insertCell();

        cell1.innerHTML = list[i]["idInvoices"];
        cell2.innerHTML = list[i]["numReference"];
        cell3.innerHTML = list[i]["dateInvoices"];
        cell4.innerHTML = list[i]["totalCancel"];
        cell5.innerHTML = list[i]["totalCanceled"];
        cell6.innerHTML = list[i]["paymentName"];
        cell7.innerHTML = list[i]["clientName"];

        let typeInvoice = parseInt(list[i]["idCredit"]);

        if (typeInvoice > 0) {
            cell8.innerHTML = "Cr\u00E9dito";
        } else {
            cell8.innerHTML = "Contado";
        }

        //let recibo = list[i]["Recibo"];
        //cell1.innerHTML = recibo;
        //cell2.innerHTML = list[i]["Fecha"];
        //let button = "'" + list[i]["Receipt_GUID"] + "'";
        //cell3.innerHTML = '<a id="' + i + '" onclick="OpenDetailsModal(' + button.toString() + ',' + "'" + list[i]["Recibo"] + "'" + ')" class="btn btn-primary" data-toggle="tooltip" data-original-title="Edit user" style="cursor:pointer; background-color: #20295b; border-color: #20295b;">Ver más</a>';
    }
}