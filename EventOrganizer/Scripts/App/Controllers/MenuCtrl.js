function MenuCtrl($scope, $location, loggedInUser) {

    loggedInUser.getUser().then(function (data) {
        $scope.user = data;
    });

    $scope.goToGroups = function() {
        $location.utl('/groups');
    };

    $scope.logOut = function () {
        loggedInUser.logOut().then(function(response) {
            if (response) {
                window.location = '/Home/Index';
            }
        });
    };
}

MenuCtrl.$inject = ['$scope', '$location', 'LoggedInUser'];