var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('GroupResource', ['$resource', function ($resource) {
    return $resource('/api/Group/:id', { id: '@Id' });
}]);