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

eventOrganizer.directive('focusable', function () {
    return {
        restrict: 'A',
        scope: {
            focusable: '@'
        },
        link: function (scope, elm, attrs) {
            scope.$watch('focusable', function (value) {
                if (value == 'true') {
                    setTimeout(function () {
                        elm[0].focus();
                    }, 500);
                }
            });
        }
    };
});
