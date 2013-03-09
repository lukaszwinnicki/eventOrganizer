var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoFocus', function ($document) {
    return {
        rectrict: 'A',
        transclude: true,
        scope: {
            eoFocus: '&'
        },
        link: function (scope, element) {
            element.on('focus', function () {
                scope.$apply(function () {
                    scope.eoFocus();
                });
            });
        }
    };
});