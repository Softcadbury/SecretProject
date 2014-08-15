(function () {
    angular
        .module('app')
        .controller('MenuCtrl', ['$scope', '$location', 'UserFactory', MenuCtrl]);

    function MenuCtrl($scope, $location, UserFactory) {
        $scope.userName = '';

        UserFactory.getCurrent().success(function (user) {
            $scope.userName = user.UserName;
        });

        $scope.getClass = function (path) {
            return $location.path() == path ? 'active' : '';
        }
    }
})();