function EventCtrl($scope, event) {
    $scope.event = event;
    $scope.commentActionDisplay = false;

    $('#comment-message').focus(function () {
        // expand input box
        $scope.$apply(function() {
            $scope.commentActionDisplay = true;
        });
    });
    
    $('#comment-message').blur(function () {
        // shrink input box
        $scope.$apply(function () {
            $scope.commentActionDisplay = false;
        });
    });
}

EventCtrl.loadEvent = function($q, $route, eventResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        eventResource.get({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

EventCtrl.$inject = ['$scope', 'loadedEvent'];
EventCtrl.loadEvent.$inject = ['$q', '$route', 'EventResource'];