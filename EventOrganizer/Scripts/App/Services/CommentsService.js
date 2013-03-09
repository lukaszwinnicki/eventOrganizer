angular.module('eventOrganizer.CommentsService', ['ngResource']).factory('CommentsResource', function ($resource) {
    return $resource('/api/Comments/:id', { id: '@Id' });
});