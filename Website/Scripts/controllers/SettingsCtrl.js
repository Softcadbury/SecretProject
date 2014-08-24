(function () {
    angular
        .module('app')
        .controller('SettingsCtrl', ['$rootScope', '$scope', SettingsCtrl]);

    function SettingsCtrl($rootScope, $scope) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.userEmail = $rootScope.currentUser ? $rootScope.currentUser.Email : '';

        // Event fired when the current user is updated
        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
            $scope.userEmail = $rootScope.currentUser.Email;
        });

        // Function to save the change of user's information
        $scope.saveChanges = function () {
            // todo : save information
            $rootScope.$broadcast('currentUser.updated');
        };

        // Function to save the change of user's password
        $scope.savePassword = function () {
            // todo : save password
            $scope.actualPassword = '';
            $scope.newPassword = '';
            $scope.passwordConfirmation = '';
        };
    }
})();