var UserService = {
    init: function () {

    },
    Create: function () {
        $.ajax("/User/CreateTest")
            .done(function () {
                //alert("success");
            })
            .fail(function () {
                alert("error");
            })
            .always(function () {
                //alert("complete");
            });
    }
};