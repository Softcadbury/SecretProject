define('user.dataservice',
    ['dataservice.helper', 'user.model'],
    function (dataserviceHelper, User) {
        var dataserviceUrl = 'users';

        // Get
        function get(id) {
            return dataserviceHelper.get(dataserviceUrl, User, id);
        };

        // Get all
        function getAll(page) {
            return dataserviceHelper.getAll(dataserviceUrl, User, page);
        };

        return {
            get: get,
            getAll: getAll
        };
    });