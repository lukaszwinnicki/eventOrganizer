var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('GroupMembersResource', ['$resource', function ($resource) {
    return $resource('/api/GroupMembers/:id', { id: '@Id' });
}]);

eventOrganizerServices.factory('JoinGroupResource', ['$resource', function ($resource) {
    return $resource('/api/JoinGroup/:id', { id: '@Id' });
}]);