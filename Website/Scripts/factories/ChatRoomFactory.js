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
            return $http.get(urlBase + '/?pageIndex=' + pageIndex);
        };

        return factory;
    }
})(angular);