(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('contactController', ['$rootScope', '$scope', 'bootstrapHelperService', 'toolFactory', contactController]);

    function contactController($rootScope, $scope, bootstrapHelperService, toolFactory) {
        resetAlerts();
        $scope.message = '';

        // Function to send the message of contact
        $scope.sendContactEmail = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);

            toolFactory.sendContactEmail($scope.message)
                .success(function () {
                    resetAlerts();
                    $scope.sendContactEmailSuccess = true;
                    $scope.message = '';
                })
                .error(function () {
                    resetAlerts();
                    $scope.sendContactEmailError = true;
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        }

        // Function to hide all alerts
        function resetAlerts() {
            $scope.sendContactEmailSuccess = false;
            $scope.sendContactEmailError = false;
        }
    }
})(angular);