angular
    .module('eventOrganizer',
        [
            'ui.bootstrap',
            'ngUpload',
            'eventOrganizer.Services',
            'eventOrganizer.Directives'])
    .config(['$routeProvider', function($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: '/Content/Partials/Groups.html',
            controller: GroupsCtrl,
            resolve: {
                loadedGroups: GroupsCtrl.loadData
            }
        });
        $routeProvider.when('/group/:id', {
            templateUrl: '/Content/Partials/Group.html',
            controller: GroupCtrl,
            resolve: {
                loadedGroup: GroupCtrl.loadGroup,
                loadedEvents: GroupCtrl.loadEvents,
                loadedGroupMembers: GroupCtrl.loadGroupMembers
            }
        });
        $routeProvider.when('/event/:id', {
            templateUrl: '/Content/Partials/Event.html',
            controller: EventCtrl,
            resolve: {
                loadedEvent: EventCtrl.loadEvent,
                eventMembers: EventCtrl.eventMembers,
                loadedComments: EventCtrl.loadComments
            }
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);
angular.module('eventOrganizer').value('eo.config', {
    images: {
        eventPlaceholder: '/Content/Images/upload-image.png',
        userPlaceholder: '/Content/Images/upload-image.png',
        userSmallPlaceholder: '/Content/Images/upload-image.png'
    }
});