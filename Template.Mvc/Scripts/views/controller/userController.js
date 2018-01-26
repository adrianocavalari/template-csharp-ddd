var UserController = function (userService) {
    var init = function () {

    };

    var OnCreate = function () {
        userService.Create();
    };
}(UserService);