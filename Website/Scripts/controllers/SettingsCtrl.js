(function () {
    angular
        .module('app')
        .controller('SettingsCtrl', ['$rootScope', '$scope', SettingsCtrl]);

    function SettingsCtrl($rootScope, $scope) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.userEmail = $rootScope.currentUser ? $rootScope.currentUser.Email : '';

        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
            $scope.userEmail = $rootScope.currentUser.Email;
        });
    }
})();