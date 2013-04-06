angular
    .module('eventOrganizer',
        [
            'eventOrganizer.EventCommentsService',
            'eventOrganizer.GroupsService',
            'eventOrganizer.GroupService',
            'eventOrganizer.GroupMembersService',
            'eventOrganizer.EventMembersService',
            'eventOrganizer.EventsService',
            'eventOrganizer.EventService',
            'eventOrganizer.JoinEventService',
            'eventOrganizer.LeaveEventService',
            'eventOrganizer.Directives',
            'ui.directives',
            'ngUpload',
            'eventOrganizer.UserServices',
            'eventOrganizer.LoggedUserServices'])
    .config(['$routeProvider', function ($routeProvider) {
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

angular.module('eventOrganizer').value('ui.config', {
    jq: {
        tooltip: {
            placement: 'top'
        }
    }
});