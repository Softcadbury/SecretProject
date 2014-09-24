(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('contactController', ['$rootScope', '$scope', 'bootstrapHelperService', 'toolFactory', contactController]);

    function contactController($rootScope, $scope, bootstrapHelperService, toolFactory) {
        $scope.message = '';

        // Function to send the message of contact
        $scope.sendContactEmail = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);

            toolFactory.sendContactEmail($scope.message)
                .success(function () {
                    $scope.message = '';
                })
                .error(function () {
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        }
    }
})(angular);