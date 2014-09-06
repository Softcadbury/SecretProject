(function (angular) {
    angular
        .module('app', ['ngRoute'])
        .config(configuration)
        .run(run);

    // Function to configure the application
    function configuration($routeProvider, $locationProvider) {
        $routeProvider.when('/about', {
            templateUrl: '/Application/AboutContent',
            controller: 'aboutController',
        });

        $routeProvider.when('/chatRooms', {
            templateUrl: '/Application/ChatRoomsContent',
            controller: 'chatRoomsController',
        });

        $routeProvider.when('/', {
            templateUrl: '/Application/HomeContent',
            controller: 'homeController',
        });

        $routeProvider.when('/settings', {
            templateUrl: '/Application/SettingsContent',
            controller: 'settingsController',
        });

        $routeProvider.when('/users', {
            templateUrl: '/Application/UsersContent',
            controller: 'usersController',
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });

        $locationProvider.html5Mode(false).hashPrefix('!');
    }

    // Function called at application runtime
    function run($rootScope, userFactory) {
        userFactory.getCurrent().
            success(function (user) {
                $rootScope.currentUser = user;
                $rootScope.$broadcast('currentUser.updated');
            });
    }
})(angular);