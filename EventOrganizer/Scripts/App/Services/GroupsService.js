angular.module('eventOrganizer.GroupsService', ['ngResource']).factory('GroupsResource', function ($resource) {
    return $resource('/api/Groups/:id', { id: '@Id' });
});