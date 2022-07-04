// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    console.log("document is ready");
    $(document).on("click", ".edit-product-button", function () {
        console.log("You just clicked button number " + $(this).val());

        var productId = $(this).val();
        $.ajax({
            type: 'json',
            data: {
                "id": productId
            },
            url: "/products/ShowOneProductJSON",
            success: function (data) {
                console.log(data);

                $("#model-input-id").val(data.id);
                $("#model-input-name").val(data.name);
                $("#model-input-price").val(data.price);
                $("#model-input-description").val(data.description);
            }
        });
    });

    $("#save-button").click(function () {
        var Product =
        {
            "Id": $("#model-input-id").val(),
            "Name": $("#model-input-name").val(),
            "Price": $("#model-input-price").val(),
            "Description": $("#model-input-description").val()
        }
        console.log("saved:");
        console.log(Product);

        $.ajax({
            type:'json',
            data: Product,
            url: '/products/ProcessEditReturnPartial',
            success: function (data) {
                console.log(data);
                $("#card-number-" + Product.Id).html(data).hide().fadeIn(2000);
            }
        })
    });



});