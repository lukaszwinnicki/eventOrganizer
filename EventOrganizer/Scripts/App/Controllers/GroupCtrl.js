function GroupCtrl($scope, $location, group, events, members, EventsResource) {
    $scope.group = group;
    $scope.editMode = false;
    $scope.modalShown = false;
    $scope.events = events;
    $scope.members = members;
    $scope.newEvent = {};

    createNewEvent();

    $scope.goToEventDetails = function(event) {
        $location.url('/event/' + event.Id);
    };

    //for (var i = 0; i < 30; i++) {
    //    $scope.members.push({ Name: 'Name', Surname: 'Surname', PhotoUrl: '/Content/Images/holder.png' });
    //}

    $scope.updateEndDate = function() {
        $scope.newEvent.EndDate = $scope.newEvent.StartDate;
    };

    $scope.updateEndHour = function() {
        $scope.newEvent.SelectedHourEnd = $scope.newEvent.SelectedHourStart;
    };

    $scope.save = function(event) {
        var eventItem = new EventsResource(event);
        eventItem.$save(function(response, responseHeader) {
            $scope.modalShown = false;
        });
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

GroupCtrl.$inject = ['$scope', '$location', 'loadedGroup', 'loadedEvents', 'loadedGroupMembers', 'EventsResource'];
GroupCtrl.loadGroup.$inject = ['$q', '$route', 'GroupResource'];
GroupCtrl.loadGroupMembers.$inject = ['$q', '$route', 'GroupMembersResource'];
GroupCtrl.loadEvents.$inject = ['$q', '$route', 'EventsResource'];