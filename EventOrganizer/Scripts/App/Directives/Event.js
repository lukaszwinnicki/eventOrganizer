var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoEvent', function () {
    return {
        rectrict: 'A',
        scope: {
            event: '=',
            eoClick: '&'
        },
        templateUrl: '/Content/Partials/Directives/Event.html'
    };
});