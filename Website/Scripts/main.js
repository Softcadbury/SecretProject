require(['menu.viewmodel'],
    function (menuViewmodel) {
        ko.applyBindings(new menuViewmodel(), document.getElementById('menu'));
    });