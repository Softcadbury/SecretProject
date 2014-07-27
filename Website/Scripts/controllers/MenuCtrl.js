(function () {
    angular
        .module('app')
        .controller('MenuCtrl', ['$scope', 'UserFactory', MenuCtrl]);

    function MenuCtrl($scope, UserFactory) {
        $scope.userName = '';

        UserFactory.get(1).success(function (user) {
            $scope.userName = user.Name;
        })
    }
})();