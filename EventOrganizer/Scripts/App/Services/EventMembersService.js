angular.module('eventOrganizer.EventMembersService', ['ngResource']).factory('EventMembersResource', function ($resource) {
    return $resource('/api/EventMembers/:id', { id: '@Id' });
});