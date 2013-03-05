function EventCtrl($scope, event) {
    $scope.event = event;
}

EventCtrl.loadEvent = function($q, $route, EventsResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        EventsResource.get({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

EventCtrl.$inject = ['$scope', 'loadedEvent'];
EventCtrl.loadEvent.$inject = ['$q', '$route', 'EventsResource'];