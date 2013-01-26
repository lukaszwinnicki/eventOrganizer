$(function() {
    $("#js-login-form").submit(function() {
        if (!$(this).valid()) {
            $(this).find(":input").each(function(i, item) {
                if (!$(item).valid()) {
                    $(item).closest(".control-group").addClass("error");
                } else {
                    $(item).closest(".control-group").removeClass("error");
                }
            });
            return false;
        }
        $.ajax("/Home/IsValidUser", {
            data: $(this).serializeArray(),
            method: "POST"
        }).done(function(data) {
            if (data.IsValid) {
                window.location = data.Url;
            } else {
                showErrorMessage(data.ErrorMessage);
            }
        });

        return false;
    });

    function showErrorMessage(errorMessage) {
        $('#js-login-error').text(errorMessage);
    }
});