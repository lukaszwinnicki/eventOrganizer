var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('EventCommentsResource', ['$resource', function ($resource) {
    return $resource('/api/EventComments/:id', { id: '@Id' });
}]);