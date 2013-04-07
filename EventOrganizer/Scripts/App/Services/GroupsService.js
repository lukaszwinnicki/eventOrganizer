var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('GroupsResource', function ($resource) {
    return $resource('/api/Groups/:id', { id: '@Id' });
});