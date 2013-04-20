var eventOrganizer = eventOrganizer || angular.module('eventOrganizer.Directives', []);

eventOrganizer.directive('eoModal', function () {
    return {
        rectrict: 'A',
        transclude: true,
        scope: {
            eoShow: '=',
            eoSave: '&',
            eoStyle: '@',
            eoTitle: '@',
            eoSaveButton: '@'
        },
        templateUrl: '/Content/Partials/Modal.html'
    };
});