var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoComment', function () {
    return {
        rectrict: 'A',
        scope: {
            comment: '='
        },
        templateUrl: '/Content/Partials/Directives/Comment.html'
    };
});