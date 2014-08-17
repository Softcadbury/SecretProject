(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$scope', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($scope, ChatRoomFactory) {
        var chatHub = $.connection.chatHub;
        $.connection.hub.start();

        $scope.chatRooms = [];
        $scope.messages = [];

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
        });

        $scope.send = function () {
            chatHub.server.send('romain', 'lola');
        };

        chatHub.client.broadcastMessage = function (name, message) {
            $scope.messages.push({ name: name, message: message });
        };
    }
})();