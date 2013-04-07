function SearchCtrl($scope, searchService) {
    var patternMinLength = 2;

    $scope.search = function(pattern) {
         if (pattern.length > patternMinLength)
         {
             searchService.search(pattern).then(function(data) {
                 console.log(data);
             });
         }
    };

}

SearchCtrl.$inject = ['$scope', 'SearchService'];
