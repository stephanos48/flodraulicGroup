var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/inventory/getall' },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'product.partNumber', "width": "25%" },
            { data: 'floLocation.locationName', "width": "25%" },
            { data: 'qoh', "width": "10%" },
            
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                        <a href='/admin/inventory/details?id=${data}' class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i></a>
                   
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

