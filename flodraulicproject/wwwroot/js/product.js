var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        'iDisplayLength': 50, 
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'imageUrl', "render": function (data) { return '<img src="' + data + '" class="avatar" width="100" height="50"/>'; }, "width": "10" },
            { data: 'partNumber', "width": "15%" },
            { data: 'description', "width": "15%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'discountPrice', "width": "10%" },
            { data: 'qoh', "width": "10%"},
            { data: 'partFamily.familyName', "width": "10" },
            //{ data: 'category.name', "width": "15" },

            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-100 btn-group" role="group">
                    <a href='/admin/product/upsert?id=${data}' class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i> Edit</a>
                    <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
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

