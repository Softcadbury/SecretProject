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

        factory.getPage = function (pageIndex) {
            return $http.get(urlBase + '/?pageIndex=' + pageIndex);
        };

        factory.add = function (user) {
            return $http.post(urlBase, user);
        };

        factory.update = function (user) {
            return $http.put(urlBase, user);
        };

        factory.remove = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        return factory;
    }
})();