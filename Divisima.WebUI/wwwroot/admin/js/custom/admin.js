$(document).ready(function () {
    $(".editor").each(function () {
        CKEDITOR.replace($(this).attr("id"));
    });
});

var silinecekID;
$(".slideDelete").click(function () {
    silinecekID = $(this).attr("rowID");
    $("#modalDelete").modal("show");
});
function deleteSlide() {
    $.ajax({
        type: "POST",
        url: "/admin/slide/delete",
        data: { id: silinecekID },
        success: function (result) {
            if (result == "Ok") {
                location.href = "/admin/slide";
            } else {
                alert(result);
            };
        }
    });
}

function deleteProductPicture() {
    $.ajax({
        type: "POST",
        url: "/admin/productPicture/delete",
        data: { id: silinecekID },
        success: function (result) {
            if (result == "Ok") {
                location.href = "/admin/productPicture";
            } else {
                alert(result);
            };
        }
    });
}

$(".brandDelete").click(function () {
    silinecekID = $(this).attr("rowID");
    $("#modalDelete").modal("show");
});
function deleteBrand() {
    $.ajax({
        type: "POST",
        url: "/admin/brand/delete",
        data: { id: silinecekID },
        success: function (result) {
            if (result == "Ok") {
                location.href = "/admin/brand";
            } else {
                alert(result);
            };
        }
    });
}

$(".categoryDelete").click(function () {
    silinecekID = $(this).attr("rowID");
    $("#modalDelete").modal("show");
});

function deleteCategory() {
    $.ajax({
        type: "POST",
        url: "/admin/category/delete",
        data: { id: silinecekID },
        success: function (result) {
            if (result == "Ok") {
                location.href = "/admin/category";
            } else {
                alert(result);
            };
        }
    });
}