(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$scope', 'SignalRService', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($scope, SignalRService, ChatRoomFactory) {
        SignalRService.initialize();
        $scope.chatRooms = [];

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
        });
    }
})();