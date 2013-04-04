function EventCtrl($scope, $route, event, members, comments, eventCommentsResource, joinEventResource) {
    $scope.event = event;
    $scope.members = members;
    $scope.comments = comments;
    $scope.commentActionDisplay = false;
    $scope.newComment = { EventId: $route.current.params.id };

    $scope.showCommentButtons = function () {
        $scope.commentActionDisplay = true;
    };

    $scope.hideCommentButtonsAndClearNewMessage = function () {
        $scope.commentActionDisplay = false;
        $scope.newComment.Message = "";
    };

    $scope.saveComment = function (comment) {
        var commentItem = new eventCommentsResource(comment);
        commentItem.$save(function (response, responseHeader) {
            $scope.comments.push(response);
            $scope.hideCommentButtonsAndClearNewMessage();
        });
    };

    // TODO : add leave functionality
    $scope.join = function () {
        var joinEvent = new joinEventResource({ EventId: $route.current.params.id });
        joinEvent.$save(function (data) {
            $scope.members.push(data);
        });
    };
}

EventCtrl.loadEvent = function ($q, $route, eventResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        eventResource.get({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

EventCtrl.loadMembers = function ($q, $route, eventMemberResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        eventMemberResource.query({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

EventCtrl.loadComments = function ($q, $route, eventCommentsResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        eventCommentsResource.query({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

EventCtrl.$inject = ['$scope', '$route', 'loadedEvent', 'loadedMembers', 'loadedComments', 'EventCommentsResource', 'JoinEventResource'];
EventCtrl.loadEvent.$inject = ['$q', '$route', 'EventResource'];
EventCtrl.loadMembers.$inject = ['$q', '$route', 'EventMembersResource'];
EventCtrl.loadComments.$inject = ['$q', '$route', 'EventCommentsResource'];