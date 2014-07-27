(function () {
    angular
        .module('app', ['ngRoute'])
        .config(configuration);

    function configuration($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: '/Home/HomeContent',
            controller: 'HomeCtrl',
        });

        $routeProvider.when('/account', {
            templateUrl: '/Home/AccountContent',
            controller: 'AccountCtrl',
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });

        $locationProvider.html5Mode(false).hashPrefix('!');
    }
})();