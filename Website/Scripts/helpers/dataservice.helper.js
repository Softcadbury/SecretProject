define('dataservice.helper',
    function () {
    	var apiUrl = './api/';

    	// Get
    	function get(dataserviceUrl, Model) {
    		var url = apiUrl + dataserviceUrl;
    		var deferred = $.Deferred();

    		ajaxRequest(url, 'GET')
				.done(function (data) {
					deferred.resolve(new Model(data));
				})
				.fail(function (data) {
					deferred.reject();
				});

    		return deferred.promise();
    	};

    	// Send an ajax request
    	function ajaxRequest(url, type, data) {
    		var options = {
    			dataType: "json",
    			contentType: "application/json",
    			cache: false,
    			type: type,
    			data: data ? data.toJson() : null
    		};

    		return $.ajax(url, options);
    	}

    	return {
    		get: get
    	};
    });