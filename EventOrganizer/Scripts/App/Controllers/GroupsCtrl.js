function GroupsCtrl($scope, $location, groupsResource, groupResource, loggedUserResource) {
    $scope.groups = [];

    groupsResource.query({}, function (data) {
        $scope.groups = data;
    });

    loggedUserResource.get({}, function (data) {
        $scope.user = data;
    });
    
    $scope.save = function (group) {
        var groupItem = new groupResource(group);
        groupItem.$save(function (response, responseHeader) {
            $scope.groups.push(response);
            $scope.modalShown = false;
        });
    };

    $scope.goToGroupDetails = function (groupId) {
        $location.url('/group/' + groupId);
    };
}

GroupsCtrl.$inject = ['$scope', '$location', 'GroupsResource', 'GroupResource', 'LoggedUserResource'];
