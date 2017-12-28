$(document).ready(function () {
    $("#editMain").change(function () {
        $.get("/ProductManagment/GetSubCategoryById", { CategoryID: $("#editMain").val() }, function (data) {
            $("#editSub").empty();
            $.each(data, function (index, row) {
                $("#editSub").append("<option value='" + row.Value + "'>" + row.Text + "</option>")
            });
        });
    })
});