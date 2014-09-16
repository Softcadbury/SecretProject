(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('contactController', ['$rootScope', '$scope', contactController]);

    function contactController($rootScope, $scope) {
        $scope.message = '';

        // Function to send the message of contact
        $scope.sendMessage = function (clickEvent) {
            $(clickEvent.target).button('loading');
        }
    }
})(angular);