function GroupCtrl($scope, $routeParams, groupResource) {
    $scope.group = {};
    $scope.editMode = false;

    if ($routeParams.id) {
        groupResource.get({ id: $routeParams.id }, function (data) {
            $scope.group = data;
        });
    }

    $scope.toggleEditMode = function (enableEditMode) {
        $scope.editMode = enableEditMode;
    };
}

GroupCtrl.$inject = ['$scope', '$routeParams', 'GroupResource'];