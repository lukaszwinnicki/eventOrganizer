var eventOrganizerServices = eventOrganizerServices || angular.module('eventOrganizer.Services', ['ngResource', 'ng']);

eventOrganizerServices.factory('SearchResource', ['$resource', function($resource) {
    return $resource('/api/Search?pattern=:pattern', { pattern: '@pattern' });
}]);

eventOrganizerServices.factory('SearchService', ['$resource', '$q', 'SearchResource', function($resource, $q, searchResource) {
    return {
        search: function (pattern) {
            var deferred = $q.defer();

            searchResource.get({ pattern: pattern }, function(data) {
                deferred.resolve(data);
            });

            return deferred.promise;
        }
    };
}]);

