var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('JoinEventResource', function ($resource) {
    return $resource('/api/JoinEvent/:id', { id: '@Id' });
});