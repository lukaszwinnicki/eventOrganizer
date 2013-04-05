angular.module('eventOrganizer.LeaveEventService', ['ngResource']).factory('LeaveEventResource', function ($resource) {
    return $resource('/api/LeaveEvent/:id', { id: '@Id' });
});