var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('UserResource', ['$resource', function ($resource) {
    return $resource('/api/User/:id', { id: '@Id' });
}]);

eventOrganizerServices.factory('UsersResource', ['$resource', function ($resource) {
    return $resource('/api/Users/:id', { id: '@Id' });
}]);

eventOrganizerServices.factory('LoggedUserResource', ['$resource', function ($resource) {
    return $resource('/api/LoggedUser');
}]);

eventOrganizerServices.factory('LoggedInUser', ['$resource', '$q', 'LoggedUserResource', function ($resource, $q, loggedUserResource) {
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
        },
        logOut: function () {
            var deferred = $q.defer();

            if (data.user !== null) {
                loggedUserResource.delete(data.user, function (response) {
                    deferred.resolve(response);
                });
            }
            else {
                deferred.resolve(false);
            }

            return deferred.promise;
        }
    };
}]);
