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

        // Function to update user's information
        $scope.updateUser = function (clickEvent) {
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

        // Function to update user's password
        $scope.updatePassword = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);

            userFactory.updateCurrentPassword($scope.actualPassword, $scope.newPassword, $scope.passwordConfirmation)
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
            bootstrapHelperService.showModal('#deleteAccountConfirmationModal');
        };

        // Function to hide all alerts
        function resetAlerts() {
            $scope.saveChangesSuccess = false;
            $scope.saveChangesError = $sce.trustAsHtml('');
            $scope.savePasswordSuccess = false;
            $scope.savePasswordError = $sce.trustAsHtml('');
        }
    }
})(angular);