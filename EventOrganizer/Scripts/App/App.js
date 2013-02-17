angular
    .module('eventOrganizer',
        [
            'eventOrganizer.GroupsService',
            'eventOrganizer.GroupService',
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
                loadedEvents: GroupCtrl.loadEvents
            }
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);