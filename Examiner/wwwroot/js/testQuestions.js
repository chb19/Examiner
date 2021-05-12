var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "data": questions,

        "columns": [
            { "data": "QuestionId", "width": "30%" },
            { "data": "QuestionText", "width": "30%" },
            { "data": "Answers", "width": "30%" },
            {
                "data": "Id",
                "render": function (data) {
                    return `<div class="text-center">
                    <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                        onclick=Delete("/Teacher/DeleteQuestionFromTest?testId=${testId}&questionId=${data}")>
                        Delete
                    </a>
                    </div>`;
                }, "width": "10%"
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
                        location.reload(true);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}