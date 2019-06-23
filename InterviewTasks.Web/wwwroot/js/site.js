// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".deleteContact").click(function () {
    var id = $(this).attr('id');
    $("#deleteContactHref").attr("href", "/ProblemSet/DeleteContact/" + id);
    $('#deleteContactModal').modal('toggle');
});