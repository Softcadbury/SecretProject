(function () {
    angular
        .module('app')
        .controller('MenuCtrl', ['$scope', '$location', 'UserFactory', MenuCtrl]);

    function MenuCtrl($scope, $location, UserFactory) {
        $scope.userName = '';

        UserFactory.get(1).success(function (user) {
            $scope.userName = user.Name;
        });

        $scope.getClass = function (path) {
            return $location.path() == path ? 'active' : '';
        }
    }
})();