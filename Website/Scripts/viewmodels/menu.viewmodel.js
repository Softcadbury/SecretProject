define('menu.viewmodel',
    ['user.dataservice', 'user.model'],
    function (userDataservice, User) {
        return function () {
            var self = this;

            self.user = ko.observable();

            userDataservice.get(1).done(function (data) {
                self.user(new User(data));
            });
        };
    });