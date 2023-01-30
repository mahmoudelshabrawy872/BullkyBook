var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data":"title","width":"75%"},
            { "data":"isbn","width":"12%"},
            { "data":"price","width":"3%"},
            { "data":"auther","width":"15%"},
            { "data":"category.name","width":"15%"},
            {
                "data": "id",
                "width": "15%",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                           <a class="btn btn-primary mx-2" href="/Admin/Product/Upsert?id=${data}"  >
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a class="btn btn-danger mx-2" href="/Admin/Product/Delete?id=${data}">
                                <i class="bi bi-trash-fill"></i>
                            </a>
                       </div>
                        `
                }
            },
        ]
        });  
}