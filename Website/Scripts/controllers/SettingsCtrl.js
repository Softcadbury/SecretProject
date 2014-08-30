﻿(function (angular) {
    angular
        .module('app')
        .controller('SettingsCtrl', ['$rootScope', '$scope', 'UserFactory', SettingsCtrl]);

    function SettingsCtrl($rootScope, $scope, UserFactory) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.userEmail = $rootScope.currentUser ? $rootScope.currentUser.Email : '';

        $scope.userUpdateSuccess = false;
        $scope.userUpdateError = false;
        $scope.passwordUpdateSuccess = false;
        $scope.passwordUpdateError = false;

        // Event fired when the current user is updated
        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
            $scope.userEmail = $rootScope.currentUser.Email;
        });

        // Function to save the change of user's information
        $scope.saveChanges = function () {
            $rootScope.currentUser.UserName = $scope.userName;
            $rootScope.currentUser.Email = $scope.userEmail;

            UserFactory.update($rootScope.currentUser).
                success(function () {
                    hideAlerts();
                    $scope.userUpdateSuccess = true;
                    $rootScope.$broadcast('currentUser.updated');
                }).
                error(function () {
                    hideAlerts();
                    $scope.userUpdateError = true;
                });
        };

        // Function to save the change of user's password
        $scope.savePassword = function () {
            UserFactory.updatePassword($rootScope.currentUser, $scope.actualPassword, $scope.newPassword, $scope.passwordConfirmation).
                success(function () {
                    hideAlerts();
                    $scope.passwordUpdateSuccess = true;
                    $scope.actualPassword = '';
                    $scope.newPassword = '';
                    $scope.passwordConfirmation = '';
                }).
                error(function () {
                    hideAlerts();
                    $scope.passwordUpdateError = true;
                });
        };

        // Function to delete the user's account
        $scope.deleteAccount = function () {
        };

        // Function to hide all alerts
        function hideAlerts() {
            $scope.userUpdateSuccess = false;
            $scope.userUpdateError = false;
            $scope.passwordUpdateSuccess = false;
            $scope.passwordUpdateError = false;
        }
    }
})(angular);