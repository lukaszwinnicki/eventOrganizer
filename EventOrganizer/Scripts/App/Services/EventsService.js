angular.module('eventOrganizer.EventsService', ['ngResource']).factory('EventsResource', function ($resource) {
    return $resource('/api/Events/:id', { id: '@Id' });
});