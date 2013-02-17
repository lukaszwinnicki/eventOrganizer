function ViewCtrl($scope) {
    $scope.isViewLoading = false;

    $scope.$on('$routeChangeStart', function () {
        $scope.isViewLoading = true;
    });
    $scope.$on('$routeChangeSuccess', function () {
        $scope.isViewLoading = false;
    });
}

ViewCtrl.$inject = ['$scope'];