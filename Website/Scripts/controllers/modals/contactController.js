(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('contactController', ['$rootScope', '$scope', '$sce', 'bootstrapHelperService', 'toolFactory', contactController]);

    function contactController($rootScope, $scope, $sce, bootstrapHelperService, toolFactory) {
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
                .error(function (data) {
                    resetAlerts();
                    $scope.sendContactEmailError = $sce.trustAsHtml(data.Message);
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        }

        // Function to hide all alerts
        function resetAlerts() {
            $scope.sendContactEmailSuccess = false;
            $scope.sendContactEmailError = $sce.trustAsHtml('');
        }
    }
})(angular);