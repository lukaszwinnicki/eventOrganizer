function GroupCtrl($scope, $routeParams, groupResource) {
    $scope.group = {};
    $scope.editMode = false;
    $scope.events = [];
    $scope.members = [];

    if ($routeParams.id) {
        groupResource.get({ id: $routeParams.id }, function (data) {
            $scope.group = data;
        });

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
    }

    $scope.toggleEditMode = function (enableEditMode) {
        $scope.editMode = enableEditMode;
    };
}

GroupCtrl.$inject = ['$scope', '$routeParams', 'GroupResource'];