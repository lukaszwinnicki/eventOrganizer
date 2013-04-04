angular.module('eventOrganizer.JoinEventService', ['ngResource']).factory('JoinEventResource', function ($resource) {
    return $resource('/api/JoinEvent/:id', { id: '@Id' });
});