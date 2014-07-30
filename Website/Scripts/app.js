(function () {
    angular
        .module('app', ['ngRoute'])
        .config(configuration);

    function configuration($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: '/Application/HomeContent',
            controller: 'HomeCtrl',
        });

        $routeProvider.when('/account', {
            templateUrl: '/Application/AccountContent',
            controller: 'AccountCtrl',
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });

        $locationProvider.html5Mode(false).hashPrefix('!');
    }
})();