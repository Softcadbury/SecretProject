define('dataservice.helper',
    function () {
        var apiUrl = './api/';

        // Get
        function get(dataserviceUrl, Model, idToGet) {
            var url = apiUrl + dataserviceUrl + '/' + idToGet;
            var deferred = $.Deferred();

            ajaxRequest(url, 'GET')
				.done(function (data) {
				    deferred.resolve(new Model(data));
				})
				.fail(function (data) {
				    deferred.reject();
				});

            return deferred.promise();
        }

        // Get all
        function getAll(dataserviceUrl, Model, pageIndex) {
            var url = apiUrl + dataserviceUrl + '?pageIndex=' + pageIndex;
            var deferred = $.Deferred();

            ajaxRequest(url, 'GET')
				.done(function (data) {
				    var models = $.map(data, function (subdata) {
				        return new Model(subdata);
				    });
				    deferred.resolve(models);
				})
				.fail(function (data) {
				    deferred.reject();
				});

            return deferred.promise();
        }

        // Add
        function add(dataserviceUrl, Model, modelToAdd) {
            var url = apiUrl + dataserviceUrl;
            var deferred = $.Deferred();

            ajaxRequest(url, 'POST', modelToAdd)
				.done(function (data) {
				    deferred.resolve(new Model(data));
				})
				.fail(function (data) {
				    deferred.reject();
				});

            return deferred.promise();
        }

        // Update
        function update(dataserviceUrl, Model, idToUpdate, modelToUpdate) {
            var url = apiUrl + dataserviceUrl + '/' + idToUpdate;
            var deferred = $.Deferred();

            ajaxRequest(url, 'PUT', modelToUpdate)
				.done(function (data) {
				    deferred.resolve(new Model(data));
				})
				.fail(function (data) {
				    deferred.reject();
				});

            return deferred.promise();
        }

        // Remove
        function remove(dataserviceUrl, idToRemove) {
            var url = apiUrl + dataserviceUrl + '/' + idToRemove;
            var deferred = $.Deferred();

            ajaxRequest(url, 'DELETE')
				.done(function (data) {
				    deferred.resolve();
				})
				.fail(function (data) {
				    deferred.reject();
				});

            return deferred.promise();
        }

        // Send an ajax request
        function ajaxRequest(url, type, data) {
            var options = {
                dataType: "json",
                contentType: "application/json",
                cache: false,
                type: type,
                data: data ? ko.toJSON(data) : null
            };

            return $.ajax(url, options);
        }

        return {
            get: get,
            getAll: getAll,
            add: add,
            update: update,
            remove: remove
        };
    });