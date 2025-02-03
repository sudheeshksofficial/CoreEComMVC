$(document).ready(function () {
    // Add to Cart Logic
    $(".add-to-cart").click(function () {
        const id = $(this).data("id");
        const name = $(this).data("name");
        const price = $(this).data("price");
        const stock = $(this).data("stock");
        const quantity = $(this).siblings(".quantity").val();

        $.post("/Item/AddCarts", { id, name, price, stock, quantity }, function (response) {
            if (response.success) {
                /* $("#cart").load("/Products/Index #cart");*/
                
                $("#successMessage").text(response.message);
                $("#successPopup").fadeIn().delay(2000).fadeOut();
            } else {
                $("#errorMessage").text(response.message);
                $("#errorPopup").fadeIn();
            }
        });
    });

    $("#closeError").click(function () {
        $("#errorPopup").fadeOut();
    });

    $("#closeSuccess").click(function () {
        $("#successPopup").fadeOut();
    });

});

