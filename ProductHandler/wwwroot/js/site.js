// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    // bind event handlers when the page loads.
    $('body').on('click', '#sortTable', function () {
        var sortOrder = $(this).attr("data-sort");
        $.ajax({
            url: "Product/SortAndFilterTable/" + sortOrder,
            type: "get",
            data: { sortOrder }, //if you need to post Model data, use this
            success: function (result) {
                $("#tableContainer").html(result);
            }
        });
    });

    $(function () {
        $('#searchForm').submit(function () {
            if ($(this).valid()) {
                //the action is send with this ajax request and the send works
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        $("#tableContainer").html(result);
                    }
                });
            }
            return false;
        });
    });
});