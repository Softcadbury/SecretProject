﻿(function () {
    angular
        .module('app')
        .controller('MenuCtrl', ['$rootScope', '$scope', '$location', MenuCtrl]);

    function MenuCtrl($rootScope, $scope, $location) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';

        // Event fired when the current user is updated
        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
        });

        // Function to know if the path is the current location
        $scope.isActive = function (path) {
            return path === $location.path();
        };
    }
})();