var dataTable;
$(document).ready(function () {
    console.log("ready");
    chargeDataTable();
});

function chargeDataTable() {
    dataTable = $("#TableCategories").DataTable({
        "ajax": {
            "url": "/Admin/Categories/GetAll",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "40%" },
            { "data": "order", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Categories/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Categories/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-trash-alt"></i> Delete
                                </a>
                          </div>
                         `;
                }, "width": "40%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "Emty Registers",
            "info": "Show _START_ a _END_ de _TOTAL_ Info",
            "infoEmpty": "Show 0 to 0 of 0 Rows",
            "infoFiltered": "(Filtered de _MAX_ total)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ Registers",
            "loadingRecords": "Load...",
            "processing": "Processing...",
            "search": "Search:",
            "zeroRecords": "0 Records Found",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Delete(url) {
    Swal.fire({
        title: "You want to delete?",
        text: "This change is permanent",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, I know",
        cancelButtonText: "Cancel",
        allowOutsideClick: false
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}