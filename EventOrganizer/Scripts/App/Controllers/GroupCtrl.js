function GroupCtrl($scope, $location, $q, $route, group, events, members, eventsResource, usersResource, joinGroupResource) {
    $scope.group = group;
    $scope.editMode = false;
    $scope.modalShown = false;
    $scope.showAddMemberDialog = false;
    $scope.events = events;
    $scope.members = members;
    $scope.users = [];
    $scope.selectedUser = {};
    $scope.newEvent = {};

    createNewEvent();

    $scope.goToEventDetails = function (event) {
        $location.url('/event/' + event.Id);
    };

    $scope.updateEndDate = function () {
        $scope.newEvent.EndDate = $scope.newEvent.StartDate;
    };

    $scope.updateEndHour = function () {
        $scope.newEvent.SelectedHourEnd = $scope.newEvent.SelectedHourStart;
    };

    $scope.filterUsers = function (pattern) {
        var defer = $q.defer();

        usersResource.query({ pattern: pattern }, function (data) {
            if (data) {
                defer.resolve(data);
            }
            else {
                defer.resolve([]);
            }
        });

        return defer.promise;
    };

    $scope.save = function (event) {
        event.GroupId = $scope.group.Id;
        var eventItem = new eventsResource(event);
        eventItem.$save(function (response, responseHeader) {
            $scope.modalShown = false;
        });
    };

    $scope.addFile = function () {
        $('#event-image').click();
    };

    $scope.addPicture = function () {
        $scope.newEvent.Photo = $('#event-image').val();
    };

    $scope.addMember = function (member) {
        var joinGroup = new joinGroupResource({ UserId: member.Id, GroupId: $route.current.params.id });
        joinGroup.$save(function (data) {
            $scope.members.push(member);
            $scope.showAddMemberDialog = false;
        });
    };

    function createNewEvent() {
        $scope.newEvent = {
            SelectedHourStart: '',
            SelectedHourEnd: '',
            Hours: [],
            Photo: 'Upload image',
            MaxParticipants: ['Unlimited'],
            Archivization: ['Automatic', 'Manual']
        };

        $scope.newEvent.Hours.push('');
        for (var l = 0; l < 24; l++) {
            $scope.newEvent.Hours.push(l);
        }
    }
}

GroupCtrl.loadGroup = function ($q, $route, groupResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        groupResource.get({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

GroupCtrl.loadGroupMembers = function ($q, $route, groupMembersResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        groupMembersResource.query({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

GroupCtrl.loadEvents = function ($q, $route, eventsResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        eventsResource.query({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

GroupCtrl.$inject = ['$scope', '$location', '$q', '$route', 'loadedGroup', 'loadedEvents', 'loadedGroupMembers', 'EventsResource', 'UsersResource', 'JoinGroupResource'];
GroupCtrl.loadGroup.$inject = ['$q', '$route', 'GroupResource'];
GroupCtrl.loadGroupMembers.$inject = ['$q', '$route', 'GroupMembersResource'];
GroupCtrl.loadEvents.$inject = ['$q', '$route', 'EventsResource'];