(function (angular) {
    'use strict';

    angular
        .module('app')
        .controller('chatRoomsController', ['$rootScope', '$scope', 'chatRoomFactory', 'signalRChatRoomFactory', chatRoomsController]);

    function chatRoomsController($rootScope, $scope, chatRoomFactory, signalRChatRoomFactory) {
        var chatHub = $.connection.chatHub;

        $scope.chatRooms = [];
        $scope.selectedChatRoomId = null;
        $scope.userName = $rootScope.currentUser ? $rootScope.currentUser.UserName : '';
        $scope.messages = [];
        $scope.newMessage = '';

        // Get the first page of chat rooms
        chatRoomFactory.getPage(1)
            .success(function (chatRooms) {
                $scope.chatRooms = chatRooms;
                $scope.selectedChatRoomId = $scope.chatRooms[0].Id;

                signalRChatRoomFactory.connect()
                    .done(function () {
                        signalRChatRoomFactory.chatRoomsParticipantsUpdate($scope.selectedChatRoomId);
                    });
            });

        // Function to know if the chat room is the selected chat room
        $scope.isActive = function (chatRoom) {
            return chatRoom.Id === $scope.selectedChatRoomId;
        }

        // Function to change the selected chat room
        $scope.changeChatRoom = function (chatRoom) {
            signalRChatRoomFactory.chatRoomsParticipantsUpdate(chatRoom.Id);
            $scope.selectedChatRoomId = chatRoom.Id;
            $scope.messages = [];
            $scope.newMessage = '';
        }

        // Function to send a message to a chat room
        $scope.sendMessageToChatRoom = function () {
            if ($scope.newMessage.trim() !== '') {
                signalRChatRoomFactory.sendMessageToChatRoom($scope.selectedChatRoomId, $scope.userName, $scope.newMessage);
                $scope.newMessage = '';
            }
        };

        // Event fired when the current user is updated
        $scope.$on('currentUser.updated', function () {
            $scope.userName = $rootScope.currentUser.UserName;
        });

        // Event fired when signalR broadcastChatRoomsParticipantsUpdate method is called
        $scope.$on('signalR.broadcastChatRoomsParticipantsUpdate', function (event, chatRoomsParticipants) {
            $scope.$apply(function () {
                $scope.chatRooms.forEach(function (chatRoom) {
                    chatRoom.Participants = chatRoomsParticipants[chatRoom.Id] ? chatRoomsParticipants[chatRoom.Id] : 0;
                });
            });
        });

        // Event fired when signalR broadcastMessageToChatRoom method is called
        $scope.$on('signalR.broadcastMessageToChatRoom', function (event, user, message) {
            $scope.$apply(function () {
                $scope.messages.push({ user: user, message: message });
            });
        });
    }
})(angular);