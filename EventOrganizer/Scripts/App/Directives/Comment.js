var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoComment', ['eo.config', function (eoConfig) {
    return {
        rectrict: 'A',
        scope: {
            comment: '='
        },
        templateUrl: '/Content/Partials/Directives/Comment.html',
        controller: function($scope) {
            var user = $scope.comment.User;
            user.PhotoUrl = user.PhotoUrl || eoConfig.images.userSmallPlaceholder;
        }
    };
}]);