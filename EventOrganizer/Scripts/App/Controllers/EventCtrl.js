function EventCtrl($scope, event) {
    $scope.event = event;
    $scope.commentActionDisplay = false;

    $scope.showCommentButtons = function () {
        $scope.commentActionDisplay = true;
    };

    $scope.hideCommentButtons = function () {
        $scope.commentActionDisplay = false;
    };
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