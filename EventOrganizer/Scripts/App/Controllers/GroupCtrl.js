function GroupCtrl($scope, group, events) {
    $scope.group = group;
    $scope.editMode = false;
    $scope.modalShown = false;
    $scope.events = events;
    $scope.members = [];
    $scope.newEvent = {};

    createNewEvent();

    for (var i = 0; i < 30; i++) {
        $scope.members.push({ Name: 'Name', Surname: 'Surname', PhotoUrl: '/Content/Images/holder.png' });
    }

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
}

GroupCtrl.loadEvents = function ($q) {
    var defer = $q.defer(),
        events = [];

    for (var j = 0; j < 30; j++) {
        var participants = [];
        for (var k = 0; k < 5; k++) {
            participants.push({
                Id: k,
                PhotoUrl: '/Content/Images/holder.png',
                Name: 'Name',
                Surname: 'Surname'
            });
        }
        events.push({
            Name: 'Integration party',
            When: new Date(2013, 2, 9, 21, 30),
            Address: {
                City: 'Sopot',
                Steet: 'Sopocka',
                Place: 'Club Sphinx'
            },
            End: new Date(2013, 2, 9, 23, 30),
            MainPhotoUrl: '/Content/Images/event-main-photo.png',
            Participants: participants
        });
    }

    defer.resolve(events);

    return defer.promise;
}

GroupCtrl.$inject = ['$scope', 'loadedGroup', 'loadedEvents'];
GroupCtrl.loadGroup.$inject = ['$q', '$route', 'GroupResource'];
GroupCtrl.loadEvents.$inject = ['$q'];