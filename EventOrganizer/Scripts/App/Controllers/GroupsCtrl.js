function GroupsCtrl($scope, $http) {
    $http.get("/api/Group").success(function (data) {
        $scope.groups = data;
    });
}
