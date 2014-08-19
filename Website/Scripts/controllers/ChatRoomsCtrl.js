(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$scope', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($scope, ChatRoomFactory) {
        var chatHub = $.connection.chatHub;
        $.connection.hub.start();

        $scope.chatRooms = [];
        $scope.messages = [];
        $scope.newMessage = '';

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
        });

        $scope.send = function () {
            chatHub.server.send('romain', $scope.newMessage);
            $scope.newMessage = '';
        };

        chatHub.client.broadcastMessage = function (user, message) {
            $scope.$apply(function() {
                $scope.messages.push({ user: user, message: message });
            });
        };
    }
})();