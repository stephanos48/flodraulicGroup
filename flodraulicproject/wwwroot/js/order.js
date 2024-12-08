var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("neworder")) {
        loadDataTable("neworder");
    }
    else {
        if (url.includes("p21entered")) {
            loadDataTable("p21entered");
        }
        else {
            if (url.includes("shippedinvoiced")) {
                loadDataTable("shippedinvoiced");
            }
            else {
                if (url.includes("paid")) {
                    loadDataTable("paid");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }

});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        //"ajax": { url:'/admin/order/getall?status=' + status },
        "ajax": { url:'/admin/order/orderlist?status=' + status},
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "25%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'applicationUser.email', "width": "20%" },
            { data: 'status.statusName', "width": "10%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                    <a href='/admin/order/details?orderId=${data}' class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i></a>
                   
                    </div>`
                },
                "width": "10%"
            }
        ]
    });
}


