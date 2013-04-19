var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('EventMembersResource', ['$resource', function ($resource) {
    return $resource('/api/EventMembers/:id', { id: '@Id' });
}]);