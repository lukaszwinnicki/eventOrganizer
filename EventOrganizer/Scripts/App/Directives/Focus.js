var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoFocus', function () {
    return {
        rectrict: 'A',
        link: function (scope, element, attr) {
            element.bind('focus', function () {
                scope.$apply(attr.eoFocus);
            });
        }
    };
});