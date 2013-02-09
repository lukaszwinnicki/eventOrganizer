function MenuCtrl($scope, loggedInUser) {

    loggedInUser.getUser().then(function (data) {
        $scope.user = data;
    });
}

MenuCtrl.$inject = ['$scope', 'LoggedInUser'];