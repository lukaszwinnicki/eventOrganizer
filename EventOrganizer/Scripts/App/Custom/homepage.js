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

    $("#js-register-form").submit(function () {
        $.ajax("/Api/Register/Save", {
            data: $(this).serializeArray(),
            method: "PUT"
        }).done(function (data) {
            if (data.IsValid) {
                window.location = data.Url;
            } else {
                $('#js-register-error').text(data.ErrorMessage);
            }
        });

        return false;
    });
    function showErrorMessage(errorMessage) {
        $('#js-login-error').text(errorMessage);
    }
});