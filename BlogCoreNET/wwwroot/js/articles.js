var dataTable;
$(document).ready(function () {
    console.log("ready");
    chargeDataTable();
});

function chargeDataTable() {
    dataTable = $("#TableArticles").DataTable({
        "ajax": {
            "url": "/Admin/Articles/GetAll",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            //el nombre como tal esta en la base de datos, solo el primero en minuscula despues como este
            { "data": "id", "width": "5%" },
            { "data": "articleName", "width": "20%" },
            { "data": "category.name", "width": "15%" },
            { "data": "articleDateCreation", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Articles/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Articles/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
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