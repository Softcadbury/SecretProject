(function () {
    angular
        .module('app')
        .factory('UserFactory', ['$http', UserFactory]);

    function UserFactory($http) {
        var urlBase = '/api/users';
        var factory = {};

        factory.getCurrent = function () {
            return $http.get(urlBase + '/current');
        };

        factory.getPage = function (pageIndex) {
            return $http.get(urlBase + '/?pageIndex=' + pageIndex);
        };

        return factory;
    }
})();