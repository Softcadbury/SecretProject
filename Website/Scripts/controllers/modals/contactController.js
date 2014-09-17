(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('contactController', ['$rootScope', '$scope', 'bootstrapHelperService', contactController]);

    function contactController($rootScope, $scope, bootstrapHelperService) {
        $scope.message = '';

        // Function to send the message of contact
        $scope.sendMessage = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);
        }
    }
})(angular);