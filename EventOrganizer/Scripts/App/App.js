angular
    .module('eventOrganizer',
        [
            'eventOrganizer.GroupsService',
            'eventOrganizer.GroupService',
            'eventOrganizer.GroupMembersService',
            'eventOrganizer.EventsService',
            'eventOrganizer.EventService',
            'eventOrganizer.Directives',
            'ui.directives',
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
                loadedEvent: EventCtrl.loadEvent
            }
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);