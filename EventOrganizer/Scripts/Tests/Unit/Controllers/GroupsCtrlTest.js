'use strict';

describe('GroupsCtrl', function () {
    var groupsCtrl,
        scope,
        groupResource,
        loggedUserResource;
    
    groupResource = {
        query: function () { }
    };

    loggedUserResource = {
        get: function () { }
    };

    beforeEach(function () {
        scope = {};
        groupsCtrl = new GroupsCtrl(scope, groupResource, loggedUserResource);
    });

    it('should have empty groups array', function () {
        expect(scope.groups).toEqual([]);
    });
});