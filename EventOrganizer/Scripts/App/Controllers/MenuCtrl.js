function MenuCtrl($scope, $location, loggedInUser) {

    loggedInUser.getUser().then(function (data) {
        $scope.user = data;
    });

    $scope.goToGroups = function() {
        $location.utl('/groups');
    };
}

MenuCtrl.$inject = ['$scope', '$location', 'LoggedInUser'];