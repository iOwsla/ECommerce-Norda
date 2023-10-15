$(document).ready(function () {
    $(".editor").each(function () {
        CKEDITOR.replace($(this).attr("id"));
    });

    // Silme işlemi için genel bir işleyici fonksiyon
    function genericDeleteHandler(buttonClass, apiUrl, redirectUrl) {
        $(buttonClass).click(function () {
            const rowID = $(this).attr("rowID");
            const productID = $(this).attr("productID"); // Sadece ürün resimleri için
            $("#modalDelete").modal("show");
            $("#confirmDeleteButton").off('click').click(function () {
                $.ajax({
                    type: "POST",
                    url: apiUrl + '/' + rowID,
                    data: { id: rowID },
                    success: function (result) {
                        if (result == "Ok") {
                            location.href = redirectUrl + (productID ? '/' + productID : '');
                        } else {
                            alert(result);
                        }
                    }
                });
            });
        });
    }

    // Silme işleyicilerini oluşturmak için genel fonksiyonu kullanma
    genericDeleteHandler(".slideDelete", "/admin/slide/delete", "/admin/slide");
    genericDeleteHandler(".brandDelete", "/admin/brand/delete", "/admin/brand");
    genericDeleteHandler(".categoryDelete", "/admin/category/delete", "/admin/category");
    genericDeleteHandler(".productDelete", "/admin/product/delete", "/admin/product");
    genericDeleteHandler(".productPictureDelete", "/admin/productPicture/delete", "/admin/productPicture");
});
