define('user.dataservice',
    ['dataservice.helper', 'user.model'],
    function (dataserviceHelper, User) {
        var dataserviceUrl = 'users';

        // Get
        function get(idToGet) {
            return dataserviceHelper.get(dataserviceUrl, User, idToGet);
        }

        // Get all
        function getAll(pageIndex) {
            return dataserviceHelper.getAll(dataserviceUrl, User, pageIndex);
        }

        // Add
        function add(modelToAdd) {
            return dataserviceHelper.add(dataserviceUrl, User, modelToAdd);
        }

        // Update
        function update(idToUpdate, modelToUpdate) {
            return dataserviceHelper.update(dataserviceUrl, User, idToUpdate, modelToUpdate);
        }

        return {
            get: get,
            getAll: getAll,
            add: add,
            update: update
        };
    });