(function (angular) {
    angular
        .module('app')
        .controller('UsersCtrl', ['$scope', 'UserFactory', UsersCtrl]);

    function UsersCtrl($scope, UserFactory) {
        $scope.users = [];
        $scope.selectedUserId = null;

        // Get the first page of users
        UserFactory.getPage(1).success(function (users) {
            $scope.users = users;
            $scope.selectedUserId = $scope.users[0].Id;
        });

        // Function to know if the user is the selected user
        $scope.isActive = function (user) {
            return user.Id === $scope.selectedUserId;
        }

        // Function to change the selected user
        $scope.changeUser = function (user) {
            $scope.selectedUserId = user.Id;
        }
    }
})(angular);