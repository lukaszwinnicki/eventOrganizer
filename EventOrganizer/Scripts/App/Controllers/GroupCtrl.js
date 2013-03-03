function GroupCtrl($scope, group, events, members) {
    $scope.group = group;
    $scope.editMode = false;
    $scope.modalShown = false;
    $scope.events = events;
    $scope.members = members;
    $scope.newEvent = {};

    createNewEvent();

    //for (var i = 0; i < 30; i++) {
    //    $scope.members.push({ Name: 'Name', Surname: 'Surname', PhotoUrl: '/Content/Images/holder.png' });
    //}

    $scope.updateEndDate = function() {
        $scope.newEvent.EndDate = $scope.newEvent.StartDate;
    };

    $scope.updateEndHour = function() {
        $scope.newEvent.SelectedHourEnd = $scope.newEvent.SelectedHourStart;
    };

    $scope.toggleEditMode = function (enableEditMode) {
        $scope.editMode = enableEditMode;

        createNewEvent();
    };

    function createNewEvent() {
        $scope.newEvent = {
            SelectedHourStart: '',
            SelectedHourEnd: '',
            Hours: [],
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

GroupCtrl.loadEvents = function($q, $route, eventsResource) {
    var defer = $q.defer(),
        params = $route.current.params;

    if (params.id) {
        eventsResource.query({ id: params.id }, function (data) {
            defer.resolve(data);
        });
    }

    return defer.promise;
};

GroupCtrl.$inject = ['$scope', 'loadedGroup', 'loadedEvents', 'loadGroupMembers'];
GroupCtrl.loadGroup.$inject = ['$q', '$route', 'GroupResource'];
GroupCtrl.loadGroupMembers.$inject = ['$q', '$route', 'GroupMembersResource'];
GroupCtrl.loadEvents.$inject = ['$q', '$route', 'EventsResource'];