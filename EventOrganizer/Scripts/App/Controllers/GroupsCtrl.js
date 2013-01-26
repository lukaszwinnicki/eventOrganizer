function GroupsCtrl($scope, groupResource, loggedUserResource) {
    $scope.groups = [];

    groupResource.query({}, function (data) {
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
}

GroupsCtrl.$inject = ['$scope', 'GroupResource', 'LoggedUserResource'];
