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

        $routeProvider.when('/settings', {
            templateUrl: '/Application/SettingsContent',
            controller: 'SettingsCtrl',
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