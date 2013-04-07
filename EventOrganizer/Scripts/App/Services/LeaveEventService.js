var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('LeaveEventResource', function ($resource) {
    return $resource('/api/LeaveEvent/:id', { id: '@Id' });
});