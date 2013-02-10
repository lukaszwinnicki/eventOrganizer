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
        $routeProvider.when('/', { templateUrl: '/Content/Partials/Groups.html', controller: GroupsCtrl });
        $routeProvider.when('/group/:id', { templateUrl: '/Content/Partials/Group.html', controller: GroupCtrl });
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);