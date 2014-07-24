define('user.dataservice',
    ['dataservice.helper', 'user.model'],
    function (dataserviceHelper, User) {
        var dataserviceUrl = 'users';

        // Get
        function get(idToGet) {
            return dataserviceHelper.get(dataserviceUrl, User, idToGet);
        }

        // Get page
        function getPage(pageIndex) {
            return dataserviceHelper.getPage(dataserviceUrl, User, pageIndex);
        }

        // Add
        function add(modelToAdd) {
            return dataserviceHelper.add(dataserviceUrl, User, modelToAdd);
        }

        // Update
        function update(idToUpdate, modelToUpdate) {
            return dataserviceHelper.update(dataserviceUrl, User, idToUpdate, modelToUpdate);
        }

        // Remove
        function remove(idToRemove) {
            return dataserviceHelper.remove(dataserviceUrl, idToRemove);
        }

        return {
            get: get,
            getPage: getPage,
            add: add,
            update: update,
            remove: remove
        };
    });