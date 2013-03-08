angular.module('eventOrganizer.EventService', ['ngResource']).factory('EventResource', function ($resource) {
    return $resource('/api/Event/:id', { id: '@Id' });
});