angular.module('eventOrganizer.EventCommentsService', ['ngResource']).factory('EventCommentsResource', function ($resource) {
    return $resource('/api/EventComments/:id', { id: '@Id' });
});