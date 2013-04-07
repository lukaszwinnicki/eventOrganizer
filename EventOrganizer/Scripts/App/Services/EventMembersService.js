var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('EventMembersResource', function ($resource) {
    return $resource('/api/EventMembers/:id', { id: '@Id' });
});