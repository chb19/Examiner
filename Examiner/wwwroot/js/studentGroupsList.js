var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": `/student/grouplist/`,
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "title", "width": "100%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                    </div>`;
                }, "width": "0%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}