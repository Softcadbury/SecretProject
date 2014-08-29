(function (angular) {
    angular
        .module('app')
        .controller('SettingsCtrl', ['$rootScope', '$scope', 'UserFactory', SettingsCtrl]);

    function SettingsCtrl($rootScope, $scope, UserFactory) {
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.userEmail = $rootScope.currentUser ? $rootScope.currentUser.Email : '';

        // Event fired when the current user is updated
        $rootScope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
            $scope.userEmail = $rootScope.currentUser.Email;
        });

        // Function to save the change of user's information
        $scope.saveChanges = function () {
            $rootScope.currentUser.UserName = $scope.userName;
            $rootScope.currentUser.Email = $scope.userEmail;
            $rootScope.$broadcast('currentUser.updated');

            // todo: check errors
            UserFactory.update($rootScope.currentUser);
        };

        // Function to save the change of user's password
        $scope.savePassword = function () {
            // todo: check errors
            UserFactory.updatePassword($rootScope.currentUser, $scope.actualPassword, $scope.newPassword, $scope.passwordConfirmation);

            $scope.actualPassword = '';
            $scope.newPassword = '';
            $scope.passwordConfirmation = '';
        };

        // Function to delete the user's account
        $scope.deleteAccount = function () {
        };
    }
})(angular);