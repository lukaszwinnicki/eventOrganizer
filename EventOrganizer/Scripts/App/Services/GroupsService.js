var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('GroupsResource', ['$resource', function ($resource) {
    return $resource('/api/Groups/:id', { id: '@Id' });
}]);