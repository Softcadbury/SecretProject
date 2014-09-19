(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('settingsController', ['$rootScope', '$scope', 'bootstrapHelperService', 'userFactory', settingsController]);

    function settingsController($rootScope, $scope, bootstrapHelperService, userFactory) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.userEmail = $rootScope.currentUser ? $rootScope.currentUser.Email : '';

        $scope.userUpdateSuccess = false;
        $scope.userUpdateError = false;
        $scope.passwordUpdateSuccess = false;
        $scope.passwordUpdateError = false;
        $scope.deleteAccountError = false;

        // Event fired when the current user is updated
        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
            $scope.userEmail = $rootScope.currentUser.Email;
        });

        // Function to open the picture cropping modal
        $scope.openPictureCroppingModal = function () {
            bootstrapHelperService.showModal('#pictureCroppingModal');
        }

        // Function to save the change of user's information
        $scope.saveChanges = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);
            $rootScope.currentUser.UserName = $scope.userName;
            $rootScope.currentUser.Email = $scope.userEmail;

            userFactory.updateCurrent($rootScope.currentUser)
                .success(function () {
                    hideAlerts();
                    $scope.userUpdateSuccess = true;
                    $rootScope.$broadcast('currentUser.updated');
                })
                .error(function () {
                    hideAlerts();
                    $scope.userUpdateError = true;
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        };

        // Function to save the change of user's password
        $scope.savePassword = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);

            userFactory.updateCurrentPassword($rootScope.currentUser, $scope.actualPassword, $scope.newPassword, $scope.passwordConfirmation)
                .success(function () {
                    hideAlerts();
                    $scope.passwordUpdateSuccess = true;
                    $scope.actualPassword = '';
                    $scope.newPassword = '';
                    $scope.passwordConfirmation = '';
                })
                .error(function () {
                    hideAlerts();
                    $scope.passwordUpdateError = true;
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        };

        // Function to delete the user's account
        $scope.deleteAccount = function () {
            userFactory.removeCurrent()
                .success(function () {
                    // Todo: redirect to home
                })
                .error(function () {
                    hideAlerts();
                    $scope.deleteAccountError = true;
                });
        };

        // Function to hide all alerts
        function hideAlerts() {
            $scope.userUpdateSuccess = false;
            $scope.userUpdateError = false;
            $scope.passwordUpdateSuccess = false;
            $scope.passwordUpdateError = false;
            $scope.deleteAccountError = false;
        }
    }
})(angular);