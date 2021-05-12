var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": `/teacher/testlist/`,
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "title", "width": "50%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                    <a href="/teacher/edittest?testId=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px;'>
                        Edit
                    </a>
                    &nbsp;
                    <a href="/teacher/testquestions/?testId=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px;'>
                        Questions
                    </a>
                    &nbsp;
                    <a class='btn btn-danger text-white' style='cursor:pointer; width:80px;'
                        onclick=Delete("/Teacher/DeleteTest?testId=${data}")>
                        Delete
                    </a>
                    </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}