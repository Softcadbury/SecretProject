(function () {
    angular
        .module('app')
        .controller('ChatRoomsCtrl', ['$scope', 'ChatRoomFactory', ChatRoomsCtrl]);

    function ChatRoomsCtrl($scope, ChatRoomFactory) {
        $scope.chatRooms = [];

        ChatRoomFactory.getPage(1).success(function (chatRooms) {
            $scope.chatRooms = chatRooms;
        });
    }
})();