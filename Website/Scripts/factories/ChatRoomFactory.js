(function (angular) {
    'use strict';

    angular
        .module('app')
        .factory('chatRoomFactory', ['$http', chatRoomFactory]);

    function chatRoomFactory($http) {
        var urlBase = '/api/chatrooms';
        var factory = {};

        // Function to get a page of chat rooms
        factory.getPage = function (pageIndex) {
            var params = {
                pageIndex: pageIndex
            };

            return $http.get(urlBase, { params: params });
        };

        return factory;
    }
})(angular);