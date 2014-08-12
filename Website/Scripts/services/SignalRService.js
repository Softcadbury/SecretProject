(function () {
    angular
        .module('app')
        .service('SignalRService', SignalRService);

    function SignalRService() {
        var initialize = function () {
            var chat = $.connection.chatHub;

            chat.client.broadcastMessage = function (name, message) {
                alert(name + message);
            };

            $.connection.hub.start().done(function () {
                window.chatMessageTest = function (name, message) {
                    chat.server.send(name, message);
                };
            });
        };

        return {
            initialize: initialize
        };
    }
})();