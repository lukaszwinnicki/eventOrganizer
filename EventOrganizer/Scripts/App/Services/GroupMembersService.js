var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('GroupMembersResource', function ($resource) {
    return $resource('/api/GroupMembers/:id', { id: '@Id' });
});