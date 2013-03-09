function EventCtrl($scope, event, commentsResource) {
    $scope.event = event;
    $scope.commentActionDisplay = false;
    $scope.newComment = { EventId: event.Id };

    $scope.showCommentButtons = function () {
        $scope.commentActionDisplay = true;
    };

    $scope.hideCommentButtonsAndClearNewMessage = function () {
        $scope.commentActionDisplay = false;
        $scope.newComment.Message = "";
    };

    $scope.saveComment = function (comment) {
        var commentItem = new commentsResource(comment);
        commentItem.$save(function (response, responseHeader) {
            $scope.event.Comments.push(response);
            $scope.hideCommentButtonsAndClearNewMessage();
        });
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

EventCtrl.$inject = ['$scope', 'loadedEvent', 'CommentsResource'];
EventCtrl.loadEvent.$inject = ['$q', '$route', 'EventResource'];