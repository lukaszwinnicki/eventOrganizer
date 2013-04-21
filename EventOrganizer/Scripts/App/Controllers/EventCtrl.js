function EventCtrl($scope, $route, $filter, event, members, comments, eventCommentsResource, joinEventResource, leaveEventResource, eventResource, loggedInUser, eoConfig) {
    $scope.loggedUserIsMemberOfEvent = false;
    $scope.event = event;
    $scope.editMode = false;
    $scope.comments = comments;
    $scope.commentActionDisplay = false;
    $scope.newComment = { EventId: $route.current.params.id };
    $scope.defaultEventImage = eoConfig.images.eventPlaceholder;
    $scope.hasImage = event.PhotoUrl != null;
    $scope.hoursInDay = [];

    members.getMembers().then(function(data) {
        $scope.members = data;
        
        loggedInUser.getUser().then(function (response) {
            $scope.user = response;
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

    $scope.uploadedPhoto = function (content, completed) {
        if(completed){
            $scope.hasImage = true;
            $scope.event.PhotoUrl = content;
        }
    };

    $scope.sendPicture = function() {
        $('#event-image-form-submitter').click();
    };

    $scope.choosePhoto = function() {
        $('#event-photo-input').click();
    };

    $scope.showCommentButtons = function () {
        $scope.commentActionDisplay = true;
    };

    $scope.hideCommentButtonsAndClearNewMessage = function () {
        $scope.commentActionDisplay = false;
        $scope.newComment.Message = "";
    };

    $scope.saveComment = function (comment) {
        comment.User = $scope.user;
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

    $scope.saveEvent = function(eventToUpdate) {
        var event = eventResource.get({ id: eventToUpdate.Id }, function () {
            event.Name = eventToUpdate.Name;
            event.Address = eventToUpdate.Address;
            event.Description = eventToUpdate.Description;
            event.StartDate = new Date(eventToUpdate.StartDate);
            event.StartDate.setHours(eventToUpdate.SelectedHourStart);
            event.EndDate = new Date(eventToUpdate.EndDate);
            event.EndDate.setHours(eventToUpdate.SelectedHourEnd);
            event.$update(function(event) {
                $scope.event = event;
                $scope.editMode = false;
            });
        });
    };

    $scope.switchToEditMode = function() {
        $scope.editMode = true;
    };

    for (var l = 0; l < 24; l++) {
        $scope.hoursInDay.push(l);
    }

    $scope.event.SelectedHourStart = parseInt($filter('date')($scope.event.StartDate, 'HH'), 10);
    $scope.event.SelectedHourEnd = parseInt($filter('date')($scope.event.EndDate, 'HH'), 10);
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

EventCtrl.$inject = ['$scope', '$route', '$filter', 'loadedEvent', 'eventMembers', 'loadedComments', 'EventCommentsResource', 'JoinEventResource', 'LeaveEventResource', 'EventResource', 'LoggedInUser', 'eo.config'];
EventCtrl.loadEvent.$inject = ['$q', '$route', 'EventResource'];
EventCtrl.eventMembers.$inject = ['$q', '$route', 'EventMembersResource'];
EventCtrl.loadComments.$inject = ['$q', '$route', 'EventCommentsResource'];