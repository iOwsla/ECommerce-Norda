$(document).ready(function () {
    $(".editor").each(function () {
        CKEDITOR.replace($(this).attr("id"));
    });

    // Silme işlemi için genel bir işleyici fonksiyon
    function genericDeleteHandler(buttonClass, apiUrl, redirectUrl) {
        $(buttonClass).click(function () {
            var rowID = $(this).attr("rowID");
            var productID = $(this).attr("productID"); // Sadece ürün resimleri için
            Swal.fire({
                title: "Emin misiniz?",
                text: "Bu işlemi geri alamazsınız!",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#d33",
                cancelButtonColor: "#3085d6",
                confirmButtonText: "Evet, sil!",
                cancelButtonText: "Hayır, vazgeç!"
            }).then((result) => {
                if (!result.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: apiUrl + '/' + rowID,
                        data: { id: rowID },
                        success: function (result) {
                            if (result == "Ok") {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Success',
                                    text: 'Item deleted!',
                                    confirmButtonText: 'Ok',
                                }).then(e => {
                                    if (e.isConfirmed) {
                                        location.href = redirectUrl + (productID ? '/' + productID : '');
                                    }
                                });
                            } else {
                                console.log(result);
                                alert(result);
                            }
                        }
                    });
                } else {
                    Swal.fire({
                        icon: 'info',
                        title: 'Cancelled',
                        text: 'Item is safe!',
                        confirmButtonText: 'Ok',
                    });
                }
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
