var eventOrganizer = angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoEvent', function () {
    return {
        rectrict: 'A',
        scope: {
            event: '='
        },
        templateUrl: '/Content/Partials/Event.html'
    }
});