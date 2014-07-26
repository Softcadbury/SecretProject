(function () {
    angular
        .module('app')
        .factory('UserFactory', ['$http', UserFactory]);

    function UserFactory($http) {
        var urlBase = '/api/users';
        var factory = {};

        factory.get = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        return factory;
    }
})();