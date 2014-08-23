(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$rootScope', '$scope', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($rootScope, $scope, ChatRoomFactory) {
        var chatHub = $.connection.chatHub;

        $scope.chatRooms = [];
        $scope.selectedRoomId = null;
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.messages = [];
        $scope.newMessage = '';

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
            $scope.selectedRoomId = $scope.chatRooms[0].Id;
        });

        $scope.isActive = function (chatRoom) {
            return chatRoom.Id === $scope.selectedRoomId;
        }

        $scope.changeRoom = function (chatRoom) {
            $scope.selectedRoomId = chatRoom.Id;
        }

        $scope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
        });

        chatHub.client.broadcastMessage = function (user, message) {
            $scope.$apply(function () {
                $scope.messages.push({ user: user, message: message });
            });
        };

        $.connection.hub.start().done(function () {
            $scope.send = function () {
                if ($scope.newMessage.trim() === '') {
                    return;
                }

                chatHub.server.send($scope.userName, $scope.newMessage);
                $scope.newMessage = '';
            };
        });
    }
})();