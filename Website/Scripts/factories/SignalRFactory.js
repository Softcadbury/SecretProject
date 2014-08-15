(function () {
    angular
        .module('app')
        .factory('SignalRFactory', SignalRFactory);

    function SignalRFactory() {
        var factory = {};

        factory.initialize = function () {
            var chat = $.connection.chatHub;

            $.connection.hub.start().done(function () {
                window.chatMessageTest = function (name, message) {
                    chat.server.send(name, message);
                };
            });

            chat.client.broadcastMessage = function (name, message) {
                alert(name + message);
            };
        };

        return factory;
    }
})();