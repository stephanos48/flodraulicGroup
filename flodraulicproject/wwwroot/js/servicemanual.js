var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/servicemanual/getall' },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'manualName', "width": "25%" },
            { data: 'manualType', "width": "25%" },
            //{ data: 'category.name', "width": "15" },

            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                    <a href='/admin/servicemanual/download?id=${data}' class="btn btn-primary mx-2"> Download</a>
                    <a href='/admin/servicemanual/upsert?id=${data}' class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i> Edit</a>
                    <a onClick=Delete('/admin/servicemanual/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "45%"
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

