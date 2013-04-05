function EventCtrl($scope, $route, event, members, comments, eventCommentsResource, joinEventResource, leaveEventResource, loggedInUser) {
    $scope.loggedUserIsMemberOfEvent = false;
    $scope.event = event;
    $scope.comments = comments;
    $scope.commentActionDisplay = false;
    $scope.newComment = { EventId: $route.current.params.id };

    members.getMembers().then(function(data) {
        $scope.members = data;
        
        loggedInUser.getUser().then(function (response) {
            $scope.user = response;
            // TODO: probably we should move this logic to server to reduce calls
            $scope.loggedUserIsMemberOfEvent = isMemberOfEvent($scope.user, $scope.members);
        });
    });
    
    function isMemberOfEvent(user, membersToCheck) {
        for (var i = 0; i < membersToCheck.length; i++) {
            if (membersToCheck[i].Id === user.Id) {
                return true;
            }
        }

        return false;
    }

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

    $scope.join = function () {
        var joinEvent = new joinEventResource({ User: $scope.user, EventId: $route.current.params.id });
        joinEvent.$save(function (data) {
            $scope.loggedUserIsMemberOfEvent = true;
            $scope.members.push(data);
        });
    };
    
    $scope.leave = function () {
        var leaveEvent = new leaveEventResource({ User: $scope.user, EventId: $route.current.params.id });
        leaveEvent.$save(function (data) {
            $scope.loggedUserIsMemberOfEvent = false;

            for (var i = 0; i < $scope.members.length; i++) {
                if($scope.members[i].Id == data.Id) {
                    $scope.members.splice(i, 1);
                    break;
                }
            }
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

EventCtrl.eventMembers = function ($q, $route, eventMemberResource) {
    var data = null;

    return {
        getMembers: function () {
            var deferred = $q.defer(), params = $route.current.params;

            if (data !== null) {
                deferred.resolve(data);
            }
            else {
                if (params.id) {
                    eventMemberResource.query({ id: params.id }, function (response) {
                        data = response;
                        deferred.resolve(response);
                    });
                }
            }

            return deferred.promise;
        }
    };
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

EventCtrl.$inject = ['$scope', '$route', 'loadedEvent', 'eventMembers', 'loadedComments', 'EventCommentsResource', 'JoinEventResource', 'LeaveEventResource', 'LoggedInUser'];
EventCtrl.loadEvent.$inject = ['$q', '$route', 'EventResource'];
EventCtrl.eventMembers.$inject = ['$q', '$route', 'EventMembersResource'];
EventCtrl.loadComments.$inject = ['$q', '$route', 'EventCommentsResource'];