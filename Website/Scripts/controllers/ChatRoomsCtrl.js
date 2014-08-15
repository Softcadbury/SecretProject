(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$scope', 'SignalRFactory', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($scope, SignalRFactory, ChatRoomFactory) {
        SignalRFactory.initialize();
        $scope.chatRooms = [];

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
        });
    }
})();