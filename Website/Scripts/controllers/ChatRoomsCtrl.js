(function (angular) {
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

        // Get the first page of chat rooms
        ChatRoomFactory.getPage(1).
            success(function (chatRooms) {
                $scope.chatRooms = chatRooms;
                $scope.selectedRoomId = $scope.chatRooms[0].Id;
            });

        // Function to know if the chat room is the selected chat room
        $scope.isActive = function (chatRoom) {
            return chatRoom.Id === $scope.selectedRoomId;
        }

        // Function to change the selected chat room
        $scope.changeRoom = function (chatRoom) {
            $scope.selectedRoomId = chatRoom.Id;
            $scope.messages = [];
            $scope.newMessage = '';
        }

        // Event fired when the current user is updated
        $scope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
        });

        // Function to send a message to a chat room
        function sendMessageToChatRoom() {
            if ($scope.newMessage.trim() !== '') {
                chatHub.server.sendMessageToChatRoom($scope.selectedRoomId, $scope.userName, $scope.newMessage);
                $scope.newMessage = '';
            }
        };

        // Function called by SignalR when a mesage is received in a chat room
        chatHub.client.broadcastMessageToChatRoom = function (user, message) {
            $scope.$apply(function () {
                $scope.messages.push({ user: user, message: message });
            });
        };

        // Register SingalR functions
        $.connection.hub.start().done(function () {
            $scope.sendMessageToChatRoom = sendMessageToChatRoom;
        });
    }
})(angular);