define('user.dataservice',
    ['dataservice.helper', 'user.model'],
    function (dataserviceHelper, User) {
        var dataserviceUrl = 'users/';

        // Get
        function get(id) {
            var url = dataserviceUrl + id;
            return dataserviceHelper.get(url, User);
        };

        return {
            get: get
        };
    });