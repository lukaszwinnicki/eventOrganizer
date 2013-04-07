function SearchCtrl($scope, $location, searchService) {
    $scope.searchResults = [];
    var patternMinLength = 2;

    $scope.search = function (pattern) {
        $scope.searchResults = [];
        if (pattern.length > patternMinLength) {
            searchService.search(pattern).then(function (data) {
                var searchResults = prepareSearchResultsToDisplay(data);

                if (searchResults.length > 0) {
                    $scope.searchResults = searchResults;
                    $('.dropdown-toggle').dropdown('toggle');
                }
            });

        }
    };

    function prepareSearchResultsToDisplay(dataFromRequest) {
        var searchResults = [];
        if (angular.isArray(dataFromRequest.Groups)) {
            angular.forEach(dataFromRequest.Groups, function(value) {
                value.GoTo = function() {
                    $location.url('/group/' + value.Id);
                };
                searchResults.push(value);
            });
        }
        if (angular.isArray(dataFromRequest.Users)) {
            angular.forEach(dataFromRequest.Users, function(value) {
                value.GoTo = function() {
                    $location.url('/');
                };
                searchResults.push(value);
            });
        }
        if (angular.isArray(dataFromRequest.Events)) {
            angular.forEach(dataFromRequest.Events, function(value) {
                value.GoTo = function() {
                    $location.url('/event/' + value.Id);
                };
                searchResults.push(value);
            });
        }
        return searchResults;
    };
}

SearchCtrl.$inject = ['$scope', '$location', 'SearchService'];
