angular.module('eventOrganizer.GroupMembersService', ['ngResource']).factory('GroupMembersResource', function ($resource) {
    return $resource('/api/GroupMembers/:id', { id: '@Id' });
});