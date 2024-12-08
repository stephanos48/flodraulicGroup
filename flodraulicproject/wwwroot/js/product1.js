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
            if (url.includes("misc")) {
                loadDataTable("misc");
            }
            else {
                loadDataTable("all");
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        'iDisplayLength': 50, 
        "ajax": { url: '/customer/home/getall?status=' + status},
        "columns": [
            { data: 'imageUrl', "render": function (data) { return '<img src="' + data + '" class="avatar" width="100" height="50"/>'; }, "width": "15" },
            { data: 'partNumber', "width": "15%" },
            { data: 'description', "width": "15%" },
            { data: 'listPrice', "width": "5%" },
            { data: 'discountPrice', "width": "5%" },
            { data: 'partFamily.familyName', "width": "10%" },
            
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                        <a href='/customer/home/details?productId=${data}' class="btn btn-primary mx-2"> Part Details</a>
                   
                    </div>`

                },
                "width": "35%"
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

