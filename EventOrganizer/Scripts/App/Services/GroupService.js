angular.module('eventOrganizer.GroupService', ['ngResource']).factory('GroupResource', function ($resource) {
    return $resource('/api/Group/:id', { id: '@Id' });
});