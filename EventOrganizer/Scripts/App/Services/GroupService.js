angular.module('eventOrganizer.Services', ['ngResource']).factory('GroupResource', function ($resource) {
    return $resource('/api/Group/:id', { id: '@Id' });
});