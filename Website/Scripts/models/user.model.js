define('user.model',
    function () {
        function UserModel(data) {
            var self = this;

            self.id = data.Id;
            self.creatorId = data.CreatorId;
            self.creationDate = data.CreationDate;
            self.modificationDate = data.ModificationDate;

            self.name = ko.observable(data.Name);
        }

        return UserModel;
    });