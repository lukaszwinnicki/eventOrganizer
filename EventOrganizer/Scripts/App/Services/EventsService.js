var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('EventsResource', ['$resource', function ($resource) {
    return $resource('/api/Events/:id', { id: '@Id' });
}]);