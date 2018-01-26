var UserController = function (userService) {
    var init = function () {
        $('#btnCreate').click(OnCreate);
    };

    var OnCreate = function () {
        userService.Create();
    };

    $(document).ready(init);
}(UserService);