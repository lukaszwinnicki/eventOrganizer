$(function() {
    $("#js-login-form").submit(function() {
        $(this).find(":input").each(function(i, item) {
            if (!$(item).valid()) {
                $(item).closest(".control-group").addClass("error");
            } else {
                $(item).closest(".control-group").removeClass("error");
            }
        });
        if (!$(this).valid()) {
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


    $("#register-button").submit(function () {
        $.ajax("/RegisterUser/Put", {
            data: $(this).serializeArray(),
            method: "PUT"
        }).done(function (data) {
            // redirect
        });

        return false;
    });
    
    function showErrorMessage(errorMessage) {
        $('#js-login-error').text(errorMessage);
    }
});