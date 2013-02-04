function GroupCtrl($scope, $routeParams, groupResource) {
    $scope.group = {};

    if ($routeParams.id) {
        groupResource.get({ id: $routeParams.id }, function (data) {
            $scope.group = data;
        });
    }
}

GroupCtrl.$inject = ['$scope', '$routeParams', 'GroupResource'];