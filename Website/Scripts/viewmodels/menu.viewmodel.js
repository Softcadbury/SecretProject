define('menu.viewmodel',
    ['user.dataservice'],
    function (userDataservice) {
        return function () {
            var self = this;

            self.user = ko.observable();
            self.users = ko.observableArray();

            userDataservice.get(1).done(function (user) {
                self.user(user);
            });

            userDataservice.getAll(1).done(function (users) {
                self.users(users);
            });
        };
    });