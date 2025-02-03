$(document).ready(function () {
    // Remove from Cart Logic
    $(document).on("click", ".remove-from-cart", function () {
        const id = $(this).data("id");

        $.post("/Item/RemoveFromCart", { id }, function (response) {
            if (response.success) {
           
                $("#successMessage").text(response.message); // Update success message
                $("#successPopup").fadeIn().delay(2000).fadeOut();
                location.reload();
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