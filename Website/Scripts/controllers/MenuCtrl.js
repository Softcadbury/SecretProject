(function () {
    angular
        .module('app')
        .controller('MenuCtrl', ['$scope', 'UserFactory', MenuCtrl]);

    function MenuCtrl($scope, UserFactory) {
        $scope.home = 'Home';
        $scope.profile = 'Profile'

        $scope.userName = 'yooo';

        UserFactory.get(1).success(function (user) {
            $scope.userName = user.Name;
        })
    }
})();