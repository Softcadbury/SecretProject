(function () {
    angular
        .module('app')
        .factory('ChatRoomFactory', ['$http', ChatRoomFactory]);

    function ChatRoomFactory($http) {
        var urlBase = '/api/chatrooms';
        var factory = {};

        // Function to get a page of chat rooms
        factory.getPage = function (pageIndex) {
            return $http.get(urlBase + '/?pageIndex=' + pageIndex);
        };

        return factory;
    }
})();