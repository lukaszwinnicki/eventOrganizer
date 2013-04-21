function SearchCtrl($scope, $location, $q, searchService, searchResource) {
    $scope.searchResults = [];
    $scope.selectedItem = null;
    var patternMinLength = 2;

    $scope.searchItems = function(pattern) {
        var deferred = $q.defer();

        if (pattern.length > patternMinLength) {

            searchResource.get({ pattern: pattern }, function(data) {
                if (data) {
                    var foundedItems = [];
                    angular.forEach(data.Users, function(value) {
                        value.Path = '/';
                        foundedItems.push(value);
                    });
                    angular.forEach(data.Groups, function(value) {
                        value.Path = '/group/' + value.Id;
                        foundedItems.push(value);
                    });
                    angular.forEach(data.Events, function(value) {
                        value.Path = '/event/' + value.Id;
                        foundedItems.push(value);
                    });
                    deferred.resolve(foundedItems);
                }
                else {
                    deferred.resolve([]);
                }
            });
        }
        else {
            deferred.resolve([]);
        }

        return deferred.promise;
    };

    $scope.goToItem = function(item) {
        if (item.Path) {
            $location.url(item.Path);
            $scope.selectedItem = null;
        }
    };
}

SearchCtrl.$inject = ['$scope', '$location', '$q', 'SearchService', 'SearchResource'];
