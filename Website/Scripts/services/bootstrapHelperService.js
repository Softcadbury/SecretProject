(function (angular) {
    'use strict';

    angular
        .module('app')
        .factory('bootstrapHelperService', bootstrapHelperService);

    function bootstrapHelperService() {
        var factory = {};

        // Function to show a modal
        factory.showModal = function (modalId) {
            $(modalId).modal('show');
        };

        // Function to put the button in a loading state
        factory.buttonToLoadingState = function (clickEvent) {
            $(clickEvent.target).button('loading');
        };

        // Function to reset the state of the button. Uses a timeout to avoid clipping and clicking spam
        factory.resetButtonState = function (clickEvent) {
            setTimeout(function () {
                $(clickEvent.target).button('reset');
            }, 500);
        };

        return factory;
    }
})(angular);