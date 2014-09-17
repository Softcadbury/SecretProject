(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('usersController', ['$scope', 'userFactory', usersController]);

    function usersController($scope, userFactory) {
        $scope.users = [];
        $scope.selectedUserId = null;

        // Get the first page of users
        userFactory.getPage(1).success(function (users) {
            $scope.users = users;
            $scope.selectedUserId = $scope.users[0].Id;
        });

        // Function to know if the user is the selected user
        $scope.isActive = function (user) {
            return user.Id === $scope.selectedUserId;
        }

        // Function to change the selected user
        $scope.changeUser = function (user) {
            $scope.selectedUserId = user.Id;
        }
    }
})(angular);