function GroupsCtrl($scope, $location, loadedGroups, groupResource, loggedInUser, eoConfig) {
    $scope.groups = loadedGroups;
    $scope.group = {};
    $scope.modalShown = false;
    $scope.hasImage = false;
    $scope.defaultUserImage = eoConfig.images.userPlaceholder;

    loggedInUser.getUser().then(function (data) {
        $scope.user = data;
        $scope.hasImage = $scope.user.PhotoUrl != null;
    });
    
    $scope.save = function (group) {
        var groupItem = new groupResource(group);
        groupItem.$save(function (response, responseHeader) {
            $scope.groups.push(response);
            $scope.modalShown = false;
        });
    };

    $scope.uploadedUserPhoto = function (content, completed) {
        if(completed){
            $scope.hasImage = true;
            $scope.user.PhotoUrl = content;
        }
    };
    
    $scope.choosePhoto = function() {
        $('#user-photo-input').click();
    };

    $scope.sendPicture = function() {
        $('#user-image-form-submitter').click();
    };

    $scope.goToGroupDetails = function (groupId) {
        $location.url('/group/' + groupId);
    };
}

GroupsCtrl.loadData = function ($q, groupsResource) {
    var defer = $q.defer();

    groupsResource.query({}, function (data) {
        defer.resolve(data);
    });

    return defer.promise;
};

GroupsCtrl.$inject = ['$scope', '$location', 'loadedGroups', 'GroupResource', 'LoggedInUser', 'eo.config'];
GroupsCtrl.loadData.$inject = ['$q', 'GroupsResource'];
