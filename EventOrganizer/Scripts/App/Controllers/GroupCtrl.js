function GroupCtrl($scope, $routeParams, groupResource) {
    $scope.group = {};
    $scope.editMode = false;
    $scope.events = [];
    $scope.members = [];
    $scope.newEvent = { };

    if ($routeParams.id) {
        groupResource.get({ id: $routeParams.id }, function (data) {
            $scope.group = data;
        });

        createNewEvent();

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
            $scope.events.push({
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

        for (var i = 0; i < 30; i++) {
            $scope.members.push({ Name: 'Name', Surname: 'Surname', PhotoUrl: '/Content/Images/holder.png' });
        }

        $scope.updateEndDate = function() {
            $scope.newEvent.EndDate = $scope.newEvent.StartDate;
        };

        $scope.updateEndHour = function() {
            $scope.newEvent.SelectedHourEnd = $scope.newEvent.SelectedHourStart;
        };
    }

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

GroupCtrl.$inject = ['$scope', '$routeParams', 'GroupResource'];