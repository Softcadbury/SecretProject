﻿(function () {
    angular
        .module('app')
        .controller('MenuCtrl', ['$rootScope', '$scope', '$location', MenuCtrl]);

    function MenuCtrl($rootScope, $scope, $location) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';

        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
        });

        $scope.isActive = function (path) {
            return path === $location.path();
        };
    }
})();