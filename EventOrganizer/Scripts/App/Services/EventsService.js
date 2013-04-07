var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('EventsResource', function ($resource) {
    return $resource('/api/Events/:id', { id: '@Id' });
});