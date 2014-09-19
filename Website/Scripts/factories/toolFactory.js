(function (angular) {
    'use strict';

    angular
        .module('app')
        .factory('toolFactory', ['$http', toolFactory]);

    function toolFactory($http) {
        var urlBase = '/api/tools';
        var factory = {};

        // Function to send a contact email
        factory.sendContactEmail = function (message) {
            return $http.post(urlBase + '/sendContactEmail');
        };

        return factory;
    }
})(angular);