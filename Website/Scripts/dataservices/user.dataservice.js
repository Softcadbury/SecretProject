define('user.dataservice',
    [],
    function () {
        function get(id) {
            return ajaxRequest('GET', './api/users/' + id);
        };

        function ajaxRequest(type, url, data) {
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