(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('settingsController', ['$rootScope', '$scope', '$sce', 'bootstrapHelperService', 'userFactory', settingsController]);

    function settingsController($rootScope, $scope, $sce, bootstrapHelperService, userFactory) {
        resetAlerts();
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.userEmail = $rootScope.currentUser ? $rootScope.currentUser.Email : '';

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
                    resetAlerts();
                    $scope.saveChangesSuccess = true;
                    $rootScope.$broadcast('currentUser.updated');
                })
                .error(function (data) {
                    resetAlerts();
                    $scope.saveChangesError = $sce.trustAsHtml(data.Message);
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
                    resetAlerts();
                    $scope.savePasswordSuccess = true;
                    $scope.actualPassword = '';
                    $scope.newPassword = '';
                    $scope.passwordConfirmation = '';
                })
                .error(function (data) {
                    resetAlerts();
                    $scope.savePasswordError = $sce.trustAsHtml(data.Message);
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
                .error(function (data) {
                    resetAlerts();
                    $scope.deleteAccountError = $sce.trustAsHtml(data.Message);
                });
        };

        // Function to hide all alerts
        function resetAlerts() {
            $scope.saveChangesSuccess = false;
            $scope.saveChangesError = false;
            $scope.savePasswordSuccess = false;
            $scope.savePasswordError = false;
            $scope.deleteAccountError = false;
        }
    }
})(angular);