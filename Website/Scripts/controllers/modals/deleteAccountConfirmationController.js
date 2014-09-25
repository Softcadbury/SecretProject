(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('deleteAccountConfirmationController', ['$rootScope', '$scope', '$sce', 'bootstrapHelperService', 'userFactory', deleteAccountConfirmationController]);

    function deleteAccountConfirmationController($rootScope, $scope, $sce, bootstrapHelperService, userFactory) {
        $scope.deleteAccountError = $sce.trustAsHtml('');

        // Function to delete the user's account
        $scope.deleteAccount = function (clickEvent) {
            bootstrapHelperService.buttonToLoadingState(clickEvent);

            userFactory.removeCurrent()
                .success(function () {
                    location.reload();
                })
                .error(function (data) {
                    $scope.deleteAccountError = $sce.trustAsHtml(data.Message);
                })
                .finally(function () {
                    bootstrapHelperService.resetButtonState(clickEvent);
                });
        };
    }
})(angular);