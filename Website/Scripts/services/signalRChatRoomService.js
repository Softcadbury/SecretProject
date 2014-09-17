(function (angular) {
    'use strict';

    angular
        .module('app')
        .factory('signalRChatRoomService', ['$rootScope', signalRChatRoomService]);

    function signalRChatRoomService($rootScope) {
        var chatHub = $.connection.chatHub;
        var factory = {};

        // Function to connect the hub
        factory.connect = function () {
            return $.connection.hub.start()
                    .done(function () {
                        // Function to send a message to a chat room
                        factory.sendMessageToChatRoom = function (chatRoomId, userName, message) {
                            chatHub.server.sendMessageToChatRoom(chatRoomId, userName, message);
                        };

                        // Function that indicates users that the current user change of chat room
                        factory.chatRoomsParticipantsUpdate = function (newChatRoomId) {
                            chatHub.server.chatRoomsParticipantsUpdate(newChatRoomId);
                        };
                    });
        };

        // Function called by SignalR to refresh the count of participants in chat rooms
        chatHub.client.broadcastChatRoomsParticipantsUpdate = function (chatRoomsParticipants) {
            $rootScope.$broadcast('signalR.broadcastChatRoomsParticipantsUpdate', chatRoomsParticipants);
        };

        // Function called by SignalR when a mesage is received in a chat room
        chatHub.client.broadcastMessageToChatRoom = function (user, message) {
            $rootScope.$broadcast('signalR.broadcastMessageToChatRoom', user, message);
        };

        return factory;
    }
})(angular);