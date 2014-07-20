﻿define('user.dataservice',
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

        // Add
        function add(modelToAdd) {
            return dataserviceHelper.add(dataserviceUrl, User, modelToAdd);
        };

        return {
            get: get,
            getAll: getAll,
            add: add
        };
    });