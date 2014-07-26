(function () {
    angular
        .module('app')
        .controller('MenuCtrl', MenuCtrl);

    function MenuCtrl($scope) {
        this.home = "Home";
        this.profile = "Profile"
    }
})();