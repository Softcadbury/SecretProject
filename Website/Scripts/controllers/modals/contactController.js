(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('contactController', ['$rootScope', '$scope', 'bootstrapHelperService', 'toolFactory', contactController]);

    function contactController($rootScope, $scope, bootstrapHelperService, toolFactory) {
        $scope.message = '';

        // Function to send the message of contact
        $scope.sendMessage = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);

            toolFactory.sendContactEmail($scope.message)
                .success(function () {
                })
                .error(function () {
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        }
    }
})(angular);