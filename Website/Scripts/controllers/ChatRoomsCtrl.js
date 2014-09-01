(function (angular) {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$rootScope', '$scope', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($rootScope, $scope, ChatRoomFactory) {
        var chatHub = $.connection.chatHub;

        $scope.chatRooms = [];
        $scope.selectedChatRoomId = null;
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.messages = [];
        $scope.newMessage = '';

        // Get the first page of chat rooms
        ChatRoomFactory.getPage(1).
            success(function (chatRooms) {
                $scope.chatRooms = chatRooms;
                $scope.selectedChatRoomId = $scope.chatRooms[0].Id;

                // Register SingalR functions
                $.connection.hub.start().done(function () {
                    $scope.sendMessageToChatRoom = sendMessageToChatRoom;
                    $scope.chatRoomsParticipantsUpdate = chatRoomsParticipantsUpdate;
                    chatRoomsParticipantsUpdate($scope.chatRooms[0].Id);
                });
            });

        // Function to know if the chat room is the selected chat room
        $scope.isActive = function (chatRoom) {
            return chatRoom.Id === $scope.selectedChatRoomId;
        }

        // Function to change the selected chat room
        $scope.changeChatRoom = function (chatRoom) {
            chatRoomsParticipantsUpdate(chatRoom.Id);
            $scope.selectedChatRoomId = chatRoom.Id;
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
                chatHub.server.sendMessageToChatRoom($scope.selectedChatRoomId, $scope.userName, $scope.newMessage);
                $scope.newMessage = '';
            }
        };

        // Function that indicates users that the current user change of chat room
        function chatRoomsParticipantsUpdate(newChatRoomId) {
            chatHub.server.chatRoomsParticipantsUpdate(newChatRoomId);
        }

        // Function called by SignalR to refresh the count of participants in chat rooms
        chatHub.client.broadcastChatRoomsParticipantsUpdate = function (chatRoomsParticipants) {
            $scope.$apply(function () {
                $scope.chatRooms.forEach(function (chatRoom) {
                    chatRoom.Participants = chatRoomsParticipants[chatRoom.Id] ? chatRoomsParticipants[chatRoom.Id] : 0;
                });
            });
        };

        // Function called by SignalR when a mesage is received in a chat room
        chatHub.client.broadcastMessageToChatRoom = function (user, message) {
            $scope.$apply(function () {
                $scope.messages.push({ user: user, message: message });
            });
        };
    }
})(angular);