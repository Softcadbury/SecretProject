define('menu.viewmodel',
    ['user.dataservice'],
    function (userDataservice) {
        return function () {
            var self = this;

            self.user = ko.observable();

            userDataservice.get(1).done(function (user) {
                self.user(user);
            });
        };
    });