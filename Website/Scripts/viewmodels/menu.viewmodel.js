define('menu.viewmodel',
    ['user.dataservice'],
    function (userDataservice) {
        return function () {
            var self = this;

            self.user = ko.observable();
            self.users = ko.observableArray();

            // Test get
            userDataservice.get(1).done(function (user) {
                self.user(user);

                // Test add
                userDataservice.add(self.user).done(function (user) {
                    console.log(user)
                });

                // Test update
                userDataservice.update(self.user().id, self.user).done(function (user) {
                    console.log(user)
                });
            });

            // Test getAll
            userDataservice.getAll(1).done(function (users) {
                self.users(users);
            });

            // Test remove
            userDataservice.remove(1).done(function () {
                console.log('removed');
            });
        };
    });