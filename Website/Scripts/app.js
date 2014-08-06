(function () {
    angular
        .module('app', ['ngRoute'])
        .config(configuration);

    function configuration($routeProvider, $locationProvider) {
        $routeProvider.when('/rooms', {
            templateUrl: '/Application/ChatRoomsContent',
            controller: 'ChatRoomsCtrl',
        });

        $routeProvider.when('/', {
            templateUrl: '/Application/HomeContent',
            controller: 'HomeCtrl',
        });

        $routeProvider.when('/account', {
            templateUrl: '/Application/AccountContent',
            controller: 'AccountCtrl',
        });

        $routeProvider.when('/users', {
            templateUrl: '/Application/UsersContent',
            controller: 'UsersCtrl',
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });

        $locationProvider.html5Mode(false).hashPrefix('!');
    }
})();