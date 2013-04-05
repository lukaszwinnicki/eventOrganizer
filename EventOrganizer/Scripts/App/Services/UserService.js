angular.module('eventOrganizer.UserServices', ['ngResource']).factory('UserResource', function ($resource) {
    return $resource('/api/User/:id', { id: '@Id' });
});

var loggedUserServices = angular.module('eventOrganizer.LoggedUserServices', ['ngResource', 'ng']);

loggedUserServices.factory('LoggedUserResource', function ($resource) {
    return $resource('/api/LoggedUser');
});

loggedUserServices.factory('LoggedInUser', ['$resource', '$q', 'LoggedUserResource', function ($resource, $q, loggedUserResource) {
    var data = { user: null };

    return {
        getUser: function () {
            var deferred = $q.defer();

            if (data.user !== null) {
                deferred.resolve(data.user);
            }
            else {
                loggedUserResource.get({}, function (response) {
                    data.user = response;
                    deferred.resolve(data.user);
                });
            }

            return deferred.promise;
        }
    };
}]);
