var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoModal', function () {
    return {
        rectrict: 'A',
        transclude: true,
        scope: {
            eoShow: '=',
            eoSave: '&',
            eoStyle: '@'
        },
        templateUrl: '/Content/Partials/Modal.html',
        link: function (scope) {
            console.log(scope);
        }
    }
});