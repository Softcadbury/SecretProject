(function (angular) {
    'use strict';

    angular
        .module('app')
        .factory('userFactory', ['$http', userFactory]);

    function userFactory($http) {
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

        // Function to update the current user
        factory.updateCurrent = function (currentUser) {
            return $http.put(urlBase + '/current', currentUser);
        };

        // Function to update the password of the current user
        factory.updateCurrentPassword = function (currentUser, actualPassword, newPassword, passwordConfirmation) {
            var updatePassword = {
                ActualPassword: actualPassword,
                NewPassword: newPassword,
                ConfirmPassword: passwordConfirmation
            };

            return $http.put(urlBase + '/current/updatePassword', updatePassword);
        };

        // Function to delete the current user
        factory.removeCurrent = function () {
            // Todo: ask for password
            return $http.delete(urlBase + '/current');
        };

        return factory;
    }
})(angular);