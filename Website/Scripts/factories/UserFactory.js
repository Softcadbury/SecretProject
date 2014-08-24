(function () {
    angular
        .module('app')
        .factory('UserFactory', ['$http', UserFactory]);

    function UserFactory($http) {
        var urlBase = '/api/users';
        var factory = {};

        // Function to get the current user
        factory.getCurrent = function () {
            return $http.get(urlBase + '/current');
        };

        // Function to get a page of users
        factory.getPage = function (pageIndex) {
            return $http.get(urlBase + '/?pageIndex=' + pageIndex);
        };

        // Function to update a user
        factory.update = function (currentUser) {
            return $http.put(urlBase + '/' + currentUser.Id, currentUser);
        };

        // Function to update the user's password
        factory.updatePassword = function (currentUser, actualPassword, newPassword, passwordConfirmation) {
            var updatePassword = {
                ActualPassword: actualPassword,
                NewPassword: newPassword,
                ConfirmPassword: passwordConfirmation
            };

            return $http.put(urlBase + '/' + currentUser.Id + '/updatePassword', updatePassword);
        };

        return factory;
    }
})();