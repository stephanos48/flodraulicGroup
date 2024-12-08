var dataTable;

$(document).ready(function () {
    $("#reportForm").submit(function (e) {
        report();
        return false;
    });
});

function report() {
    var params;

    params = '&fromDate=' + $('#fromDate').val() + '&toDate=' + $('#toDate').val();

    $.ajax({
        type: 'GET',
        url: '/admin/order/orderlistreport?' + params,
        success: function (results) {
            $('#searchResults').empty();

            $.each(results, function (orderlistreport, order) {
                var html =
                    '<tr>' +
                    '<td>' + order.Id + '<td>' +
                    '<td>' + order.OrderDate + '<td>' +
                    '<td>' + order.PurchaseOrderNo + '<td>' +
                    '<td>' + order.Email + '<td>' +
                    '<td>' + order.ListOrderTotal + '<td>' +
                    '<td>' + order.OrderTotal + '<td>' +
                    '<tr>';

                $('#searchResults').append(html.toString());
            });

        },
        error: function () {
            alert('Error performing search, try again later!')
        }


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

