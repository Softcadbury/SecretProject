(function (angular) {
    angular
        .module('app')
        .controller('UsersCtrl', ['$scope', 'UserFactory', UsersCtrl]);

    function UsersCtrl($scope, UserFactory) {
        $scope.users = [];

        // Get the first page of users
        UserFactory.getPage(1).success(function (users) {
            $scope.users = users;
        });
    }
})(angular);