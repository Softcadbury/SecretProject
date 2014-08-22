(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$rootScope', '$scope', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($rootScope, $scope, ChatRoomFactory) {
        var chatHub = $.connection.chatHub;
        $.connection.hub.start();

        $scope.chatRooms = [];
        $scope.messages = [];
        $scope.newMessage = '';
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';

        $scope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
        });

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
        });

        $scope.send = function () {
            if ($scope.newMessage.trim() == '') {
                return;
            }

            chatHub.server.send($scope.userName, $scope.newMessage);
            $scope.newMessage = '';
        };

        chatHub.client.broadcastMessage = function (user, message) {
            $scope.$apply(function () {
                $scope.messages.push({ user: user, message: message });
            });
        };
    }
})();