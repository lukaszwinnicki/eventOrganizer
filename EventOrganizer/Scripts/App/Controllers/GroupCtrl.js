function GroupCtrl($scope, $routeParams, groupResource) {
    $scope.gropu = {};

    if ($routeParams.id) {
        groupResource.get({ id: id }, function (data) {
            $scope.group = data;
        });
    }
}

GroupCtrl.$inject = ['$scope', '$routeParams', 'GroupResource'];