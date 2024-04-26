var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("tractor")) {
        loadDataTable("tractor");
    }
    else {
        if (url.includes("trailer")) {
            loadDataTable("trailer");
        }
        else {
              loadDataTable("all");
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/customer/home/getall?status=' + status},
        "columns": [
            { data: 'partNumber', "width": "15%" },
            { data: 'description', "width": "25%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'qoh', "width": "10%" },
            { data: 'partFamily.familyName', "width": "15%" },
            
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                    <a href='/admin/order/details?orderId=${data}' class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i></a>
                   
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}

