angular.module('eventOrganizer.UserServices', ['ngResource']).factory('UserResource', function ($resource) {
    return $resource('/api/User/:id', { id: '@Id' });
});

angular.module('eventOrganizer.LoggedUserServices', ['ngResource']).factory('LoggedUserResource', function ($resource) {
    return $resource('/api/LoggedUser');
});
