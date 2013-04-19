var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('EventResource', ['$resource', function ($resource) {
    return $resource('/api/Event/:id', { id: '@Id' });
}]);